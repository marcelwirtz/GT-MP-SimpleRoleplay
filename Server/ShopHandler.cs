using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.ItemService;
using SimpleRoleplay.Server.Services.MoneyService;
using SimpleRoleplay.Server.Services.ShopService;
using System.Linq;

namespace SimpleRoleplay.Server
{
	class ShopHandler 
		: Script
	{
		public ShopHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments) 
		{
			Shop shop = null;
			Player player = null;
			switch (eventName)
			{
				case "KeyboardKey_E_Pressed":
					if (client.isInVehicle)
						return;
					if (!client.hasData("player"))
						return;
					shop = ShopService.ShopList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2);
					if (shop == null)
						return;
					if(shop.Storage.Count == 0)
					{
						API.sendPictureNotificationToPlayer(client, "Sorry, we don't sell anything at the moment..", "CHAR_BLOCKED", 0, 0, "ID: ~b~" + shop.Id, "Shop");
						return;
					}
					ShopService.OpenShopMenu(client, shop);
					break;

				case "ShopBuyItem":
					if (!client.hasData("player"))
						return;
					player = client.getData("player");
					shop = ShopService.ShopList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2);
					if(shop == null)
					{
						// No shop nearby
						API.sendNotificationToPlayer(client, "~r~No shop nearby!");
						ShopService.CloseShopMenu(client);
						return;
					}

					ShopItem item = shop.Storage.FirstOrDefault(x => x.Id == (int)arguments[0]);
					if(item == null)
					{
						// Not in the assortment
						API.sendNotificationToPlayer(client, "~r~Not in the assortment!");
						ShopService.CloseShopMenu(client);
						return;
					}

					if (!MoneyService.HasPlayerEnoughCash(client, item.BuyPrice))
					{
						// Not enough Cash
						API.sendNotificationToPlayer(client, "~r~Not enough Cash!");
						ShopService.CloseShopMenu(client);
						return;
					}

					if(item.Count <= 0)
					{
						// Sold Out
						API.sendNotificationToPlayer(client, "~r~This item is sold out!");
						ShopService.CloseShopMenu(client);
						return;
					}

					Item itemInfo = ItemService.ItemList.FirstOrDefault(x => x.Id == item.Id);
					if(itemInfo == null)
					{
						// Item Doen't exist
						API.sendNotificationToPlayer(client, "~r~This item doesn't exist!");
						ShopService.CloseShopMenu(client);
						return;
					}

					InventoryItem invitem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == item.Id);
					if(invitem == null)
					{
						player.Character.Inventory.Add(new InventoryItem
						{
							ItemID = item.Id,
							Count = 1
						});
					}
					else
					{
						invitem.Count++;
					}
					
					item.Count--;
					MoneyService.RemovePlayerCash(client, item.BuyPrice);
					shop.MoneyStorage += item.BuyPrice;
					API.sendNotificationToPlayer(client, "~g~Buyed ~w~1x " + itemInfo.Name + " ~g~for ~w~" + item.BuyPrice + " $");
					ShopService.RefreshBuyMenu(client, shop);
					//ShopService.CloseShopMenu(client);
					break;

				case "ShopSellItem":
					if (!client.hasData("player"))
						return;
					player = client.getData("player");
					shop = ShopService.ShopList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 2);
					if (shop == null)
					{
						// No shop nearby
						API.sendNotificationToPlayer(client, "~r~No shop nearby!");
						ShopService.CloseShopMenu(client);
						return;
					}
					InventoryItem invItem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == (int)arguments[0]);
					if(invItem == null)
					{
						// Doesn't own this item
						API.sendNotificationToPlayer(client, "~r~You does not own this item!");
						ShopService.CloseShopMenu(client);
					}
					itemInfo = ItemService.ItemList.FirstOrDefault(x => x.Id == invItem.ItemID);
					if (itemInfo == null)
					{
						// Item Doen't exist
						API.sendNotificationToPlayer(client, "~r~This item doesn't exist!");
						ShopService.CloseShopMenu(client);
						return;
					}
					if(invItem.Count <= 0)
					{
						// You does not own this item!
						API.sendNotificationToPlayer(client, "~r~You does not own this item!");
						player.Character.Inventory.Remove(invItem);
					}
					invItem.Count--;
					if (invItem.Count <= 0)
						player.Character.Inventory.Remove(invItem);
					item = shop.Storage.FirstOrDefault(x => x.Id == invItem.ItemID);
					if (item != null)
						item.Count++;
					MoneyService.AddPlayerCash(client, itemInfo.DefaultSellPrice);
					API.sendNotificationToPlayer(client, "~g~Sold ~w~1x " + itemInfo.Name + " ~g~for ~w~" + itemInfo.DefaultSellPrice + " $");
					ShopService.RefreshBuyMenu(client, shop);
					break;
			}
		}

	}
}
