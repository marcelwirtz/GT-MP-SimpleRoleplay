using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.FactionService;
using SimpleRoleplay.Server.Services.VehicleService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleRoleplay.Server
{
	class GarageHandler 
		: Script
	{
		public GarageHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments) //arguments param can contain multiple params
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			if (eventName == "KeyboardKey_E_Pressed")
			{
				if (!client.isInVehicle)
				{
					if (client.hasData("player"))
					{
						Garage garage = GarageService.GarageList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2f);
						if (garage == null)
						{
							//API.sendNotificationToPlayer(client, "~r~No garage nearby!");
							return;
						}

						if (garage.FactionType != FactionType.Citizen)
						{
							if (garage.FactionType != player.Character.Faction) { return; }
						}

						List<GarageMenuItem> menuitems = new List<GarageMenuItem>();
						VehicleService.GetUserVehicles(client).ForEach(ownedVehicle => 
						{
							VehicleInfo vehicleInfo = VehicleService.GetVehicleInfo(ownedVehicle.ModelName);
							if (vehicleInfo != null && GarageService.IsVehicleTypeAllowed(vehicleInfo.Type, garage.Type)) {
								if (player.Character.OnDuty)
								{
									if(ownedVehicle.Faction == FactionType.Citizen || ownedVehicle.Faction == player.Character.Faction)
									menuitems.Add(new GarageMenuItem
									{
										Id = ownedVehicle.Id,
										ModelName = ownedVehicle.ModelName,
										VehHash = ownedVehicle.Model,
										NumberPlate = ownedVehicle.NumberPlate,
										Description = "~b~FuelType~w~: " + VehicleService.GetVehicleInfo(ownedVehicle.ModelName).Fuel.ToString()
									});
								}
								else
								{
									if (ownedVehicle.Faction == FactionType.Citizen)
									{
										menuitems.Add(new GarageMenuItem
										{
											Id = ownedVehicle.Id,
											ModelName = ownedVehicle.ModelName,
											VehHash = ownedVehicle.Model,
											NumberPlate = ownedVehicle.NumberPlate,
											Description = "~b~FuelType~w~: " + VehicleService.GetVehicleInfo(ownedVehicle.ModelName).Fuel.ToString()
										});
									}
								}
							}
						});
						API.triggerClientEvent(client, "Garage_OpenMenu", JsonConvert.SerializeObject(menuitems));
						return;
					}
				}
			}

			if(eventName == "Garage_UseVehicle")
			{
				Garage garage = GarageService.GarageList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2f);
				if (garage == null)
				{
					API.sendNotificationToPlayer(client, "~r~No garage nearby!");
					return;
				}

				if (garage.FactionType != FactionType.Citizen)
				{
					if (garage.FactionType != player.Character.Faction) { return; }
				}

				OwnedVehicle ownedVehicle = VehicleService.LoadFromDatabase((int)arguments[0]);
				if(ownedVehicle == null)
				{
					API.sendNotificationToPlayer(client, "~r~Could not find requested Vehicle!");
					return;
				}

				bool freeSpawnAvailable = false;
				GarageSpawn freespawn = null;
				garage.Spawnpoints.ForEach(spawn =>
				{
					if (!freeSpawnAvailable)
					{
						OwnedVehicle foundblockingveh = VehicleService.OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(spawn.Position) <= 6f);
						if(foundblockingveh == null)
						{
							freeSpawnAvailable = true;
							freespawn = spawn;
						}
					}
				});

				if(freespawn == null)
				{
					API.sendNotificationToPlayer(client, "~r~No free Spawnpoint found!");
					return;
				}
				Vehicle newVehicle = API.createVehicle(ownedVehicle.Model, freespawn.Position, freespawn.Rotation, ownedVehicle.PrimaryColor, ownedVehicle.SecondaryColor);
				newVehicle.numberPlate = ownedVehicle.NumberPlate;
				ownedVehicle.ActiveHandle = newVehicle;
				newVehicle.setData("vehicle", ownedVehicle);
				newVehicle.setSyncedData("fuel", ownedVehicle.Fuel);
				newVehicle.setSyncedData("maxfuel", VehicleService.GetVehicleInfo(ownedVehicle.ModelName).MaxFuel); // Read From DB Later
				newVehicle.engineHealth = ownedVehicle.EngineHealth;
				newVehicle.locked = true;
				newVehicle.engineStatus = false;
				newVehicle.livery = ownedVehicle.Livery;
				VehicleService.OwnedVehicleList.Add(ownedVehicle);
				VehicleService.SetInUse(ownedVehicle, true);
				API.sendNotificationToPlayer(client, "~g~Vehicle Successful Parked Out!");
				GarageService.CloseMenu(client);
				return;
			}

			if(eventName == "Garage_ParkVehicle")
			{
				Garage garage = GarageService.GarageList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2f);
				if (garage == null)
				{
					API.sendNotificationToPlayer(client, "~r~No garage nearby!");
					return;
				}
				if(garage.FactionType != FactionType.Citizen)
				{
					if(garage.FactionType != player.Character.Faction) { return; }
				}

				float vehicleDistance = 10f; // Default Distance Vehicle <=> Garage
				switch (garage.Type)
				{
					case GarageType.GroundVehicle:
						vehicleDistance = 10f;
						break;
					case GarageType.Helicopter:
					case GarageType.Plane:
						vehicleDistance = 20f;
						break;
					case GarageType.Boat:
						vehicleDistance = 30f;
						break;
				}

				OwnedVehicle ownedVehicle = VehicleService.OwnedVehicleList.FirstOrDefault(x => x.Owner == client.socialClubName && x.OwnerCharId == player.Character.Id && x.ActiveHandle.position.DistanceTo(garage.Position) <= vehicleDistance);
				if(ownedVehicle == null)
				{
					API.sendNotificationToPlayer(client, "~r~Could not find any Vehicle to Park!");
					return;
				}

				GarageService.ParkVehicle(ownedVehicle);
				API.sendNotificationToPlayer(client, "~g~Vehicle Successful Parked!");
				GarageService.CloseMenu(client);
				return;
			}
		}
	}
}
