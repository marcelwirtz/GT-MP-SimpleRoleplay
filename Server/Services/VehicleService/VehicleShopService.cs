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
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Services.VehicleService
{
	class VehicleShopService
	{
		public static readonly List<VehicleShop> VehShopList = new List<VehicleShop>();

		public static void LoadAllVehicleShopsFromDB()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM vehicleshops", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					VehicleShop vehicleShop = new VehicleShop
					{
						Id = (int)row["Id"],
						Position = JsonConvert.DeserializeObject<Vector3>((string)row["Position"]),
						PedHeading = (float)row["PedHeading"],
						PreviewPosition = JsonConvert.DeserializeObject<Vector3>((string)row["PreviewPosition"]),
						PreviewRotation = JsonConvert.DeserializeObject<Vector3>((string)row["PreviewRotation"]),
						PreviewCamera = JsonConvert.DeserializeObject<Vector3>((string)row["PreviewCamera"]),
						VehType = (VehicleType)row["VehType"],
						FactionType = (FactionType)row["FactionType"],
						SellingVehicles = JsonConvert.DeserializeObject<Dictionary<string, double>>((string)row["SellingVehicles"]),
						BlipSprite = (int)row["BlipSprite"],
						Name = (string)row["Name"]
					};
					if(vehicleShop.FactionType == FactionType.Citizen)
					{
						vehicleShop.MapMarker = API.shared.createBlip(vehicleShop.Position);
						vehicleShop.MapMarker.shortRange = true;
						vehicleShop.MapMarker.sprite = vehicleShop.BlipSprite;
						vehicleShop.MapMarker.scale = 0.75f;
						vehicleShop.MapMarker.name = vehicleShop.Name;
						BlipService.BlipService.BlipList.Add(vehicleShop.MapMarker);
					}
					vehicleShop.Ped = API.shared.createPed(PedHash.Autoshop01SMM, vehicleShop.Position, vehicleShop.PedHeading);
					VehShopList.Add(vehicleShop);
				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Vehicle Shops Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No Vehicle Shops Loaded..");
			}
		}

		public static void AddVehicleShop(Client client, string name)
		{
			VehicleShop vehicleShop = new VehicleShop();
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Position", JsonConvert.SerializeObject(client.position) },
				{ "@PedHeading", client.rotation.Z.ToString().Replace(",", ".") },
				{ "@PreviewPosition", JsonConvert.SerializeObject(vehicleShop.PreviewPosition) },
				{ "@PreviewRotation", JsonConvert.SerializeObject(vehicleShop.PreviewRotation) },
				{ "@PreviewCamera", JsonConvert.SerializeObject(vehicleShop.PreviewCamera) },
				{ "@VehType", ((int)vehicleShop.VehType).ToString() },
				{ "@SellingVehicles", JsonConvert.SerializeObject(vehicleShop.SellingVehicles) },
				{ "@BlipSprite", vehicleShop.BlipSprite.ToString() },
				{ "@Name", name }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO vehicleshops (Position, PedHeading, PreviewPosition, PreviewRotation, PreviewCamera, VehType, SellingVehicles, BlipSprite, Name) " +
				"VALUES (@Position, @PedHeading, @PreviewPosition, @PreviewRotation, @PreviewCamera, @VehType, @SellingVehicles, @BlipSprite, @Name)", parameters);
			ReloadVehicleShops();
		}

		public static void ReloadVehicleShops()
		{
			VehShopList.ForEach(vehicleShop =>
			{
				if (vehicleShop.MapMarker != null)
					API.shared.deleteEntity(vehicleShop.MapMarker);
				if (vehicleShop.Ped != null)
					API.shared.deleteEntity(vehicleShop.Ped);
			});
			VehShopList.Clear();
			LoadAllVehicleShopsFromDB();
		}

		public static void ChangePreviewPosition(int vehicleShopId, Client client)
		{
			VehicleShop vehicleShop = VehShopList.FirstOrDefault(x => x.Id == vehicleShopId);
			if (vehicleShop == null)
				return;
			vehicleShop.PreviewPosition = client.position;
			vehicleShop.PreviewRotation = client.rotation;
			UpdateVehicleShop(vehicleShop);
		}

		public static void ChangePreviewCamera(int vehicleShopId, Client client)
		{
			VehicleShop vehicleShop = VehShopList.FirstOrDefault(x => x.Id == vehicleShopId);
			if (vehicleShop == null)
				return;
			vehicleShop.PreviewCamera = new Vector3(client.position.X, client.position.Y, client.position.Z + 2);
			UpdateVehicleShop(vehicleShop);
		}

		public static void UpdateVehicleShop(VehicleShop vehicleShop)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", vehicleShop.Id.ToString() },
				{ "@Position", JsonConvert.SerializeObject(vehicleShop.Position) },
				{ "@PedHeading", vehicleShop.PedHeading.ToString().Replace(",", ".") },
				{ "@PreviewPosition", JsonConvert.SerializeObject(vehicleShop.PreviewPosition) },
				{ "@PreviewRotation", JsonConvert.SerializeObject(vehicleShop.PreviewRotation) },
				{ "@PreviewCamera", JsonConvert.SerializeObject(vehicleShop.PreviewCamera) },
				{ "@VehType", ((int)vehicleShop.VehType).ToString() },
				{ "@FactionType", ((int)vehicleShop.FactionType).ToString() },
				{ "@SellingVehicles", JsonConvert.SerializeObject(vehicleShop.SellingVehicles) },
				{ "@BlipSprite", vehicleShop.BlipSprite.ToString() }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE vehicleshops SET Position = @Position, PedHeading = @PedHeading, PreviewPosition = @PreviewPosition, " +
				"PreviewRotation = @PreviewRotation, PreviewCamera = @PreviewCamera, VehType = @VehType, SellingVehicles = @SellingVehicles," +
				"BlipSprite = @BlipSprite, FactionType = @FactionType WHERE Id = @Id LIMIT 1", parameters);
		}

		public static void OpenVehicleShop(Client client)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			VehicleShop vehicleShop = VehShopList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2f);
			if(vehicleShop == null) { return; }

			if (vehicleShop.FactionType != FactionType.Citizen)
			{
				if (vehicleShop.FactionType != player.Character.Faction) { return; }
			}

			if (vehicleShop.SellingVehicles.Count == 0)
			{
				API.shared.sendPictureNotificationToPlayer(client, "Sorry, we don't sell anything at the moment..", "CHAR_BLOCKED", 0, 0, "ID: ~b~" + vehicleShop.Id, "Vehicle Shop");
				return;
			}
			List<VehicleShopMenuItem> MenuItems = new List<VehicleShopMenuItem>();
			vehicleShop.SellingVehicles.ToList().ForEach(vehicle => {
				MenuItems.Add(new VehicleShopMenuItem {
					Name = vehicle.Key,
					Description = vehicle.Value + " $",
					VehHash = API.shared.getHashKey(vehicle.Key),
					InfoFuel = VehicleService.GetVehicleInfo(vehicle.Key).Fuel.ToString(),
					InfoStorage = VehicleService.GetVehicleInfo(vehicle.Key).MaxStorage.ToString(),
					InfoMaxSpeed = Math.Round(Convert.ToDouble(API.shared.getVehicleMaxSpeed(API.shared.vehicleNameToModel(vehicle.Key))) * 3.6).ToString()
				});
			});

			API.shared.triggerClientEvent(client, "VehicleShop_OpenMenu", JsonConvert.SerializeObject(MenuItems), vehicleShop.PreviewPosition, vehicleShop.PreviewRotation, vehicleShop.PreviewCamera, vehicleShop.Name);
		}

		public static void CloseVehicleShop(Client client)
		{
			API.shared.triggerClientEvent(client, "VehicleShop_CloseMenu");
		}

		public static void BuyVehicle(Client client, string modelName)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			VehicleShop vehicleShop = VehShopList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2f);
			if (vehicleShop == null)
			{
				API.shared.sendNotificationToPlayer(client, "~o~Could not find Vehicle Shop..");
				CloseVehicleShop(client);
				return;
			}
			if (!vehicleShop.SellingVehicles.ContainsKey(modelName))
			{
				API.shared.sendNotificationToPlayer(client, "~o~Could not find requested Vehicle..");
				CloseVehicleShop(client);
				return;
			}
			if (!MoneyService.MoneyService.HasPlayerEnoughBank(client, vehicleShop.SellingVehicles[modelName]))
			{
				API.shared.sendNotificationToPlayer(client, "~r~You don't have enough Money!");
				CloseVehicleShop(client);
				return;
			}

			OwnedVehicle ownedVehicle = new OwnedVehicle {
				Owner = client.socialClubName,
				OwnerCharId = player.Character.Id,
				ModelName = modelName,
				Fuel = 5,
				PrimaryColor = -1,
				EngineHealth = 1000,
				SecondaryColor = -1,
				NumberPlate = "No Lic",
				Faction = vehicleShop.FactionType
			};

			VehicleService.CreateNewVehicle(ownedVehicle);
			MoneyService.MoneyService.RemovePlayerBank(client, vehicleShop.SellingVehicles[modelName]);
			API.shared.sendNotificationToPlayer(client, "~g~You bought a ~b~" + modelName + "~g~ for ~b~" + vehicleShop.SellingVehicles[modelName] + "$~n~" +
				"~o~Your vehicle was delivered to your garage.");
			CloseVehicleShop(client);
		}

		public static void AddShopItem(int vehicleShopId, string modelName, double price)
		{
			VehicleShop vehicleShop = VehShopList.FirstOrDefault(x => x.Id == vehicleShopId);
			if (vehicleShop == null)
				return;
			vehicleShop.SellingVehicles.Add(modelName, price);
			UpdateVehicleShop(vehicleShop);
		}
	}
}
