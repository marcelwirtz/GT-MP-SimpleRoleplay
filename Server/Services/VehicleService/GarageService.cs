using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.FactionService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SimpleRoleplay.Server.Services.VehicleService
{
	class GarageService 
		: Script
	{
		public static readonly List<Garage> GarageList = new List<Garage>();

		public GarageService()
		{
			API.onResourceStop += OnResourceStopHandler;
		}

		public void OnResourceStopHandler()
		{
			GarageList.ForEach(garage =>
			{
				if (garage.MapMarker != null)
					API.deleteEntity(garage.MapMarker);
				if (garage.Ped != null)
					API.deleteEntity(garage.Ped);
			});
			GarageList.Clear();
		}

		public static void LoadAllGarageFromDB()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM garages", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					Garage garage = new Garage
					{
						Id = (int) row["Id"],
						Position = new Vector3((float) row["PosX"], (float) row["PosY"], (float) row["PosZ"]),
						PedRotation = (float) row["PedRotation"],
						Spawnpoints = JsonConvert.DeserializeObject<List<GarageSpawn>>((string) row["Spawnpoints"]),
						FactionType = (FactionType)row["FactionType"],
						Type = (GarageType)row["Type"]
					};
					garage.Ped = API.shared.createPed(PedHash.Andreas, garage.Position, garage.PedRotation);
					if(garage.FactionType == FactionType.Citizen)
					{
						garage.MapMarker = API.shared.createBlip(garage.Position);
						garage.MapMarker.sprite = 50;
						garage.MapMarker.scale = 0.75f;
						garage.MapMarker.name = "Garage";
						garage.MapMarker.shortRange = true;
						BlipService.BlipService.BlipList.Add(garage.MapMarker);
					}
					GarageList.Add(garage);

				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Garages Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No Garages Loaded..");
			}
		}

		public static void CloseMenu(Client client)
		{
			API.shared.triggerClientEvent(client, "Garage_CloseMenu");
		}

		public static void SaveSpawnpoints(Garage garage)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", garage.Id.ToString() },
				{ "@Spawnpoints", JsonConvert.SerializeObject(garage.Spawnpoints) }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE garages SET Spawnpoints = @Spawnpoints WHERE Id = @Id LIMIT 1", parameters);
		}

		public static void AddSpawnpoint(int garageId, Vector3 position, Vector3 rotation)
		{
			Garage garage = GarageList.FirstOrDefault(x => x.Id == garageId);
			if (garage == null)
				return;
			garage.Spawnpoints.Add(new GarageSpawn
			{
				Position = position,
				Rotation = rotation
			});
			SaveSpawnpoints(garage);
		}

		public static void AddSpawnpoint(int garageId, Client client)
		{
			Garage garage = GarageList.FirstOrDefault(x => x.Id == garageId);
			if (garage == null)
				return;
			garage.Spawnpoints.Add(new GarageSpawn
			{
				Position = client.position,
				Rotation = client.rotation
			});
			SaveSpawnpoints(garage);
		}

		public static void AddGarage(Vector3 position, double heading)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", position.X.ToString().Replace(",", ".") },
				{ "@PosY", position.Y.ToString().Replace(",", ".") },
				{ "@PosZ", position.Z.ToString().Replace(",", ".") },
				{ "@PedRotation", heading.ToString().Replace(",", ".") }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO garages (PosX, PosY, PosZ, PedRotation) " +
				"VALUES (@PosX, @PosY, @PosZ, @PedRotation)", parameters);
		}

		public static void AddGarage(Client client)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", client.position.X.ToString().Replace(",", ".") },
				{ "@PosY", client.position.Y.ToString().Replace(",", ".") },
				{ "@PosZ", client.position.Z.ToString().Replace(",", ".") },
				{ "@PedRotation", client.rotation.Z.ToString().Replace(",", ".") }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO garages (PosX, PosY, PosZ, PedRotation) " +
				"VALUES (@PosX, @PosY, @PosZ, @PedRotation)", parameters);
		}

		public static void ReloadGarages()
		{
			GarageList.ForEach(garage => 
			{
				if (garage.MapMarker != null)
					API.shared.deleteEntity(garage.MapMarker);
				if (garage.Ped != null)
					API.shared.deleteEntity(garage.Ped);
			});
			GarageList.Clear();
			LoadAllGarageFromDB();
		}

		public static bool IsVehicleTypeAllowed(VehicleType vehicleType, GarageType garageType)
		{
			bool returnvalue = false;
			switch (vehicleType)
			{
				case VehicleType.Car:
				case VehicleType.Truck:
				case VehicleType.Motorcycle:
				case VehicleType.Cycles:
					if(garageType == GarageType.GroundVehicle) { returnvalue = true; }
					break;
				case VehicleType.Helicopter:
					if (garageType == GarageType.Helicopter) { returnvalue = true; }
					break;
				case VehicleType.Plane:
					if(garageType == GarageType.Plane) { returnvalue = true; }
					break;
				case VehicleType.Boat:
					if(garageType == GarageType.Boat) { returnvalue = true; }
					break;

			}
			return returnvalue;
		}

		public static void ParkVehicle(OwnedVehicle ownedVehicle)
		{
			ownedVehicle.EngineHealth = Convert.ToInt32(ownedVehicle.ActiveHandle.engineHealth);
			VehicleService.UpdateVehicle(ownedVehicle);
			API.shared.deleteEntity(ownedVehicle.ActiveHandle);
			VehicleService.SetInUse(ownedVehicle, false);
			VehicleService.OwnedVehicleList.Remove(ownedVehicle);
		}
	}
}
