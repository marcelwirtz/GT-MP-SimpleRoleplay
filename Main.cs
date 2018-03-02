using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using Newtonsoft.Json;
using SimpleRoleplay.Server;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.AdminService;
using SimpleRoleplay.Server.Services.CharacterService;
using SimpleRoleplay.Server.Services.ClothingService;
using SimpleRoleplay.Server.Services.FactionService;
using SimpleRoleplay.Server.Services.ItemService;
using SimpleRoleplay.Server.Services.MoneyService;
using SimpleRoleplay.Server.Services.ShopService;
using SimpleRoleplay.Server.Services.VehicleService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SimpleRoleplay
{
	public class Main 
		: Script
	{
		public Main()
		{
			API.onClientEventTrigger += OnClientEvent;
		}

		[Command("cloth")]
		public void OpenCloth(Client sender)
		{
			API.triggerClientEvent(sender, "open_ClothingCreator");
		}

		public void OnClientEvent(Client player, string eventName, params object[] arguments)
		{
			switch (eventName)
			{
				case "save_clothing":
					Clothing cloth = new Clothing();
					cloth.Slot = 11;
					cloth.Drawable = (int)arguments[0];
					cloth.Texture = (int)arguments[1];
					cloth.Torso = (int)arguments[2];
					cloth.Undershirt = (int)arguments[3];
					cloth.Gender = ((Player)player.getData("player")).Character.Gender;


					Dictionary<string, string> parameters = new Dictionary<string, string>
					{
						{ "@Slot", cloth.Slot.ToString() },
						{ "@Drawable", cloth.Drawable.ToString() },
						{ "@Texture", cloth.Texture.ToString() },
						{ "@Torso", cloth.Torso.ToString() },
						{ "@Undershirt", cloth.Undershirt.ToString() },
						{ "@Gender", ((int)cloth.Gender).ToString() }
					};
					DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO clothes_tops (Slot, Drawable, Texture, Torso, Undershirt, Gender) " +
						"VALUES (@Slot, @Drawable, @Texture, @Torso, @Undershirt, @Gender)", parameters);
					break;
			}
		}
		
		[Command("addoutfit", GreedyArg = true)]
		public void AddOutfit(Client client, Gender gender, string name)
		{
			Outfit outfit = new Outfit
			{
				Name = name,
				Gender = gender
			};

			Dictionary<string, string> parameters = new Dictionary<string, string>
					{
						{ "@Outfit", JsonConvert.SerializeObject(outfit) }
					};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO clothes_outfits (Outfit) " +
				"VALUES (@Outfit)", parameters);
		}

		[Command("addatm")]
		public void AddATMCmd(Client player)
		{
			ATMService.AddATM(player.position);
			API.sendChatMessageToPlayer(player, "~b~ATM ~w~added..");
		}

		[Command("anim")]
		public void Animation(Client client, string dict, string anim)
		{
			API.playPlayerAnimation(client, (int)(AnimationFlags.StopOnLastFrame), dict, anim);
		}

		[Command("testinventory")]
		public void TestInventory(Client client)
		{
			Player player = client.getData("player");
			API.sendChatMessageToPlayer(client, "Inventar:");
			if (player.Character.Inventory.Count != 0)
			{
				player.Character.Inventory.ForEach(delegate (InventoryItem item)
				{
					Item dbitem = ItemService.ItemList.Find(x => x.Id == item.ItemID);
					API.sendChatMessageToPlayer(client, "- " + dbitem.Name + "(" + item.ItemID + ")");
				});
			}
		}

		[Command("livery")]
		public void ChangeLivery(Client client, int id)
		{
			if (client.isInVehicle)
			{
				client.vehicle.livery = id;
			}
		}

		[Command("additem")]
		public void AddItem(Client client, int id)
		{
			Player player = client.getData("player");
			player.Character.Inventory.Add(new InventoryItem { ItemID = id, Count = 1 });
			API.sendChatMessageToPlayer(client, "Added Item ID " + id + " to Player Inventory");
		}

		[Command("tyresmoke")]
		public void TestTyreSmoke(Client client, int r, int g, int b)
		{
			if (!client.isInVehicle) { return; }
			client.vehicle.setMod(20, 1);
			client.vehicle.tyreSmokeColor = new Color(r, g, b);
		}

		[Command("addshop")]
		public void AddShop(Client client)
		{
			ShopService.AddShop(client.position);
			API.sendChatMessageToPlayer(client, "Shop Created");
		}

		[Command("addshopped")]
		public void AddShopPed(Client client, int shopId)
		{
			Shop shop = ShopService.LoadShopFromDB(shopId);
			shop.PedPosition = client.position;
			shop.PedRotation = client.rotation;
			ShopService.SaveShop(shop);
			shop.Ped = API.createPed(PedHash.AmmuCountrySMM, shop.PedPosition, shop.PedRotation.Z);

		}

		[Command("addshopitem")]
		public void AddShopItem(Client client, int shopId, int itemId, double price, int count)
		{
			Shop shop = ShopService.ShopList.Find(x => x.Id == shopId);
			shop.Storage.Add(new ShopItem {
				Id = itemId,
				BuyPrice = price,
				SellPrice = price / 2,
				Count = count

			});
			API.sendChatMessageToPlayer(client, "Added");
		}

		[Command("stats")]
		public void StatsCmd(Client client)
		{
			Player player = client.getData("player");
			API.sendChatMessageToPlayer(client, "~y~PLAYER~w~| Hunger: ~o~" + player.Character.Hunger + " ~w~| Thirst: ~b~" + player.Character.Thirst);
			API.sendChatMessageToPlayer(client, "~y~SYNCED~w~| Hunger: ~o~" + client.getSyncedData("hunger") + " ~w~| Thirst: ~b~" + client.getSyncedData("thirst"));
		}

		[Command("avehicle", Alias ="aveh")]
		public void AdminVehicle(Client client, string vehicle)
		{
			AdminService.SpawnAdminVehicle(client, vehicle);
		}

		[Command("addgarage")]
		public void AddGarageCmd(Client client)
		{
			GarageService.AddGarage(client);
			API.sendChatMessageToPlayer(client, "Garage added");
		}

		[Command("addgaragespawn")]
		public void AddGarageSpawnCmd(Client client, int garageId)
		{
			GarageService.AddSpawnpoint(garageId, client);
			API.sendChatMessageToPlayer(client, "Garage spawn added");
		}
		
		[Command("reloadgarages")]
		public void ReloadGarages(Client client)
		{
			GarageService.ReloadGarages();
			API.sendChatMessageToPlayer(client, "Garages reloading");
		}

		[Command("addgasstation")]
		public void AddGasStationCmd(Client client)
		{
			GasStationService.AddGasStation(client);
			API.sendChatMessageToPlayer(client, "Gas Station added");
			GasStationService.ReloadGasStations();
		}

		[Command("addgasstationpump")]
		public void AddGasStationPumpCmd(Client client, int gasstationid)
		{
			GasStationService.AddGasPump(gasstationid, client);
			API.sendChatMessageToPlayer(client, "Gas Station Pump added");
		}

		[Command("reloadgasstations")]
		public void ReloadGasStations(Client client)
		{
			GasStationService.ReloadGasStations();
			API.sendChatMessageToPlayer(client, "Gas Stations reloading");
		}

		[Command("forceweather")]
		public void AdminForceWeather(Client client, int weatherId)
		{
			AdminService.ForceWeather(client, weatherId);
		}
		
		[Command("addvehicleshop")]
		public void AddVehicleShop(Client client, string shopName)
		{
			VehicleShopService.AddVehicleShop(client, shopName);
			API.sendChatMessageToPlayer(client, "Vehicle Shop added");
		}

		[Command("changevehicleshoppreview")]
		public void ChangeVehShopPreview(Client client, int shopId)
		{
			VehicleShopService.ChangePreviewPosition(shopId, client);
			API.sendChatMessageToPlayer(client, "Vehicle Shop Preview Changed");
		}

		[Command("changevehicleshopcamera")]
		public void ChangeVehShopCamera(Client client, int shopId)
		{
			VehicleShopService.ChangePreviewCamera(shopId, client);
			API.sendChatMessageToPlayer(client, "Vehicle Shop Camera Changed");
		}

		[Command("addvehicleshopitem")]
		public void AddVehicleShopItem(Client client, int shopId, string modelName, double price)
		{
			VehicleShopService.AddShopItem(shopId, modelName, price);
			API.sendChatMessageToPlayer(client, modelName + " added to ShopID " + shopId + " for " + price + "$");
		}

		[Command("addclothingshop")]
		public void AddClothingShop(Client client)
		{
			ClothingShopService.AddClothingShop(client.position);
		}

		[Command("addclothingshopped")]
		public void AddClothingShopPed(Client client, int clothingShopId)
		{
			ClothingShopService.ChangePedPosition(clothingShopId, client.position, client.rotation.Z);
		}

		[Command("addclothingshopitem")]
		public void AddClothingShopItem(Client client, int clothingShopId, string type, int id)
		{
			ClothingShop clothingShop = ClothingShopService.ClothingShopList.FirstOrDefault(x => x.Id == clothingShopId);
			Clothing clothing;
			if (clothingShop == null) { return; }
			switch (type)
			{
				case "top":
					clothing = ClothingService.TopList.FirstOrDefault(x => x.Id == id);
					if(clothing == null) { return; }
					if(clothingShop.AvailableTops.FirstOrDefault(x => x.Id == id) != null) { return; }
					clothingShop.AvailableTops.Add(clothing);
					API.sendChatMessageToPlayer(client, "Top ID: " + id + " added to Shop " + clothingShopId);
					break;
				case "leg":
					clothing = ClothingService.LegList.FirstOrDefault(x => x.Id == id);
					if (clothing == null) { return; }
					if (clothingShop.AvailableLegs.FirstOrDefault(x => x.Id == id) != null) { return; }
					clothingShop.AvailableLegs.Add(clothing);
					API.sendChatMessageToPlayer(client, "Leg ID: " + id + " added to Shop " + clothingShopId);
					break;
				case "feet":
					clothing = ClothingService.FeetList.FirstOrDefault(x => x.Id == id);
					if (clothing == null) { return; }
					if (clothingShop.AvailableFeets.FirstOrDefault(x => x.Id == id) != null) { return; }
					clothingShop.AvailableFeets.Add(clothing);
					API.sendChatMessageToPlayer(client, "Feet ID: " + id + " added to Shop " + clothingShopId);
					break;
			}
			ClothingShopService.SaveClothingShop(clothingShopId);
		}
	}
}
