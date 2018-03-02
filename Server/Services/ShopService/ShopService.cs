using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SimpleRoleplay.Server.Services.ShopService
{
	public class ShopService 
		: Script
	{
		public static readonly List<Shop> ShopList = new List<Shop>();

		public ShopService()
		{
			API.onResourceStop += OnResourceStopHandler;
		}

		public void OnResourceStopHandler()
		{
			ShopList.ForEach(shop => 
			{
				if (shop.Blip != null)
					API.deleteEntity(shop.Blip);
				if (shop.Ped != null)
					API.deleteEntity(shop.Ped);
				SaveShop(shop);
			});
			ShopList.Clear();
		}

		public static void LoadShopsFromDB()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM shops", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					Shop shop = new Shop
					{
						Id = (int) row["Id"],
						Owner = (string) row["Owner"],
						Storage = JsonConvert.DeserializeObject<List<ShopItem>>((string) row["Storage"]),
						MoneyStorage = (double) row["MoneyStorage"],
						Position = new Vector3((float) row["PosX"], (float) row["PosY"], (float) row["PosZ"]),
						PedPosition = new Vector3((float) row["PedPosX"], (float) row["PedPosY"], (float) row["PedPosZ"]),
						PedRotation = new Vector3(0, 0, (float) row["PedRot"]),
						MenuImage = (string) row["MenuImage"],
						Blip = API.shared.createBlip(new Vector3((float) row["PosX"], (float) row["PosY"], (float) row["PosZ"]))
					};

					shop.Blip.sprite = 52;
					shop.Blip.scale = 0.5f;
					shop.Blip.name = "Shop";
					shop.Blip.shortRange = true;
					BlipService.BlipService.BlipList.Add(shop.Blip);

					shop.Ped = API.shared.createPed(PedHash.AmmuCountrySMM, shop.PedPosition, shop.PedRotation.Z);

					ShopList.Add(shop);
				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Shops Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No Shops Loaded..");
			}
		}

		public static Shop LoadShopFromDB(int id)
		{
			Shop shop = null;
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@Id", id.ToString()}
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM shops WHERE Id = @Id LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					shop = new Shop
					{
						Id = (int)row["Id"],
						Owner = (string)row["Owner"],
						Storage = JsonConvert.DeserializeObject<List<ShopItem>>((string)row["Storage"]),
						MoneyStorage = (double)row["MoneyStorage"],
						Position = new Vector3((float)row["PosX"], (float)row["PosY"], (float)row["PosZ"]),
						PedPosition = new Vector3((float)row["PedPosX"], (float)row["PedPosY"], (float)row["PedPosZ"]),
						PedRotation = new Vector3(0, 0, (float)row["PedRot"])
					};
				}
			}
			return shop;
		}

		public static void SaveShop(Shop shop)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", shop.Id.ToString() },
				{ "@Owner", shop.Owner },
				{ "@Storage", JsonConvert.SerializeObject(shop.Storage)},
				{ "@MoneyStorage", shop.MoneyStorage.ToString() },
				{ "@PosX", shop.Position.X.ToString().Replace(",", ".") },
				{ "@PosY", shop.Position.Y.ToString().Replace(",", ".") },
				{ "@PosZ", shop.Position.Z.ToString().Replace(",", ".") },
				{ "@PedPosX", shop.PedPosition.X.ToString().Replace(",", ".") },
				{ "@PedPosY", shop.PedPosition.Y.ToString().Replace(",", ".") },
				{ "@PedPosZ", shop.PedPosition.Z.ToString().Replace(",", ".") },
				{ "@PedRot", shop.PedRotation.Z.ToString().Replace(",", ".") }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE shops SET Owner = @Owner, Storage = @Storage, MoneyStorage = @MoneyStorage," +
				"PosX = @PosX, PosY = @PosY, PosZ = @PosZ, PedPosX = @PedPosX, PedPosY = @PedPosY, PedPosZ = @PedPosZ, PedRot = @PedRot WHERE Id = @Id LIMIT 1", parameters);
		}

		public static Shop AddShop(Vector3 position)
		{
			Shop shop = new Shop();
			shop.Position = position;
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Storage", JsonConvert.SerializeObject(shop.Storage)},
				{ "@MoneyStorage", shop.MoneyStorage.ToString() },
				{ "@PosX", shop.Position.X.ToString().Replace(",", ".") },
				{ "@PosY", shop.Position.Y.ToString().Replace(",", ".") },
				{ "@PosZ", shop.Position.Z.ToString().Replace(",", ".") },
				{ "@PedPosX", shop.PedPosition.X.ToString().Replace(",", ".") },
				{ "@PedPosY", shop.PedPosition.Y.ToString().Replace(",", ".") },
				{ "@PedPosZ", shop.PedPosition.Z.ToString().Replace(",", ".") },
				{ "@PedRot", shop.PedRotation.Z.ToString().Replace(",", ".") }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO shops (Storage, MoneyStorage, PosX, PosY, PosZ, PedPosX, PedPosY, PedPosZ, PedRot) " +
				"VALUES (@Storage, @MoneyStorage, @PosX, @PosY, @PosZ, @PedPosX, @PedPosY, @PedPosZ, @PedRot)", parameters);

			shop.Blip = API.shared.createBlip(shop.Position);
			shop.Blip.sprite = 52;
			shop.Blip.name = "Shop";
			shop.Blip.shortRange = true;

			BlipService.BlipService.BlipList.Add(shop.Blip);
			ShopList.Add(shop);
			return shop;
		}

		public static void OpenShopMenu(Client client, Shop shop)
		{
			List<ShopMenuItem> shopItems = new List<ShopMenuItem>();
			shop.Storage.ForEach(item => 
			{
				shopItems.Add(new ShopMenuItem
				{
					Id = item.Id,
					Name = ItemService.ItemService.ItemList.First(x => x.Id == item.Id).Name,
					BuyPrice = item.BuyPrice,
					SellPrice = item.SellPrice,
					Count = item.Count
				});
			});

			List<InventoryMenuItem> shopInventoryItems = new List<InventoryMenuItem>();
			Player player = client.getData("player");
			player.Character.Inventory.ForEach(item =>
			{
				Item invitem = ItemService.ItemService.ItemList.First(x => x.Id == item.ItemID);
				if (invitem == null)
					return;
				if (invitem.Sellable)
				{
					shopInventoryItems.Add(new InventoryMenuItem
					{
						Id = item.ItemID,
						Name = invitem.Name,
						Description = invitem.DefaultSellPrice.ToString(),
						Count = item.Count
					});
				}
			});

			SaveShop(shop);

			API.shared.triggerClientEvent(client, "Shop_OpenMenu", JsonConvert.SerializeObject(shopItems), JsonConvert.SerializeObject(shopInventoryItems), shop.MenuImage);
		}

		public static void RefreshBuyMenu(Client client, Shop shop)
		{
			List<ShopMenuItem> shopItems = new List<ShopMenuItem>();
			shop.Storage.ForEach(item =>
			{
				shopItems.Add(new ShopMenuItem
				{
					Id = item.Id,
					Name = ItemService.ItemService.ItemList.First(x => x.Id == item.Id).Name,
					BuyPrice = item.BuyPrice,
					SellPrice = item.SellPrice,
					Count = item.Count
				});
			});

			List<InventoryMenuItem> shopInventoryItems = new List<InventoryMenuItem>();
			Player player = client.getData("player");
			player.Character.Inventory.ForEach(item =>
			{
				Item invitem = ItemService.ItemService.ItemList.First(x => x.Id == item.ItemID);
				if (invitem == null)
					return;
				if (invitem.Sellable)
				{
					shopInventoryItems.Add(new InventoryMenuItem
					{
						Id = item.ItemID,
						Name = invitem.Name,
						Description = invitem.DefaultSellPrice.ToString(),
						Count = item.Count
					});
				}
			});

			API.shared.triggerClientEvent(client, "Shop_RefreshShopMenu", JsonConvert.SerializeObject(shopItems), JsonConvert.SerializeObject(shopInventoryItems));
		}

		public static void CloseShopMenu(Client client)
		{
			API.shared.triggerClientEvent(client, "Shop_CloseMenu");
		}
	}
}
