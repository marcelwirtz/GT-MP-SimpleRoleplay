using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.FactionService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Timers;

namespace SimpleRoleplay.Server.Services.ItemService
{
	class ItemService
	{
		public static readonly List<Item> ItemList = new List<Item>();

		public static void LoadItemsFromDB()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM items", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					ItemList.Add(new Item
					{
						Id = (int)row["Id"],
						Name = (string)row["Name"],
						Description = (string)row["Description"],
						Type = (ItemType)((int)row["Type"]),
						Weight = (int)row["Weight"],
						DefaultPrice = (double)row["DefaultPrice"],
						DefaultSellPrice = (double)row["DefaultSellPrice"],
						Value1 = (int)row["Value1"],
						Value2 = (int)row["Value2"],
						Sellable = Convert.ToBoolean((int)row["Sellable"])
					});
				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Items Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No Items Loaded..");
			}
		}

		public static void ItemAction(Client client, Player player, Item item)
		{
			OwnedVehicle ownedVehicle = null;
			switch (item.Type)
			{
				case ItemType.Special:
					break;
				case ItemType.Food: // Value 1 = Hunger | Value 2 = Thirst
					player.Character.Hunger += item.Value1;
					player.Character.Thirst += item.Value2;
					break;
				case ItemType.Drink: // Value 1 = Hunger | Value 2 = Thirst
					player.Character.Hunger += item.Value1;
					player.Character.Thirst += item.Value2;
					break;
				case ItemType.Medic: // Value 1 = Heal Amount | Value 2 = none
					client.health += item.Value1;
					break;
				case ItemType.Repair: // Value 1 = Repair Amount | Value 2 = none
					ownedVehicle = VehicleService.VehicleService.OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 2);
					if (ownedVehicle == null)
					{
						API.shared.sendNotificationToPlayer(player.Character.Player, "~r~Can't find any Vehicle..");
						return;
					}
					ownedVehicle.ActiveHandle.repair();
					ownedVehicle.EngineHealth = 4000;
					break;
				case ItemType.FuelCanister:
					ownedVehicle = VehicleService.VehicleService.OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 2);
					if (ownedVehicle == null)
					{
						API.shared.sendNotificationToPlayer(player.Character.Player, "~r~Can't find any Vehicle..");
						return;
					}
					ownedVehicle.Fuel += item.Value1;
					ownedVehicle.ActiveHandle.setSyncedData("fuel", ownedVehicle.Fuel);
					break;
				case ItemType.Drug: // Value 1 = DrugType | Value 2 = Intense
					break;
			}

			InventoryItem invitem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == item.Id);

			invitem.Count--;
			if (invitem.Count <= 0)
				player.Character.Inventory.Remove(invitem);
			CharacterService.CharacterService.UpdateHUD(client);
			UpdateInventar(client);
			API.shared.sendNotificationToPlayer(player.Character.Player, "You use a ~g~" + item.Name);
		}

		public static bool UseItem(Client client, int id)
		{
			if (!client.hasData("player"))
				return false;
			if (client.hasData("usagetimer"))
			{
				API.shared.sendNotificationToPlayer(client, "~r~You already started an action..");
				return false;
			}
			Player player = client.getData("player");
			InventoryItem invitem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == id);
			if (invitem == null)
				return false;
			Item item = ItemList.FirstOrDefault(x => x.Id == id);
			if (item == null)
				return false;
			OwnedVehicle ownedVehicle = null;
			switch (item.Type)
			{
				case ItemType.Special:
					StartUsageTimer(client, player, item, 0);
					break;
				case ItemType.Food: // Value 1 = Hunger | Value 2 = Thirst
					StartUsageTimer(client, player, item, 0);
					API.shared.playPlayerAnimation(client, (int)(AnimationFlags.OnlyAnimateUpperBody), "mp_player_intdrink", "loop");
					API.shared.delay(1500, true, () => {
						API.shared.stopPlayerAnimation(client);
					});
					break;
				case ItemType.Drink: // Value 1 = Hunger | Value 2 = Thirst
					StartUsageTimer(client, player, item, 0);
					API.shared.playPlayerAnimation(client, (int)(AnimationFlags.OnlyAnimateUpperBody), "mp_player_inteat@burger", "mp_player_int_eat_burger");
					API.shared.delay(1500, true, () => {
						API.shared.stopPlayerAnimation(client);
					});
					break;
				case ItemType.Medic: // Value 1 = Heal Amount | Value 2 = none
					StartUsageTimer(client, player, item, 10);
					break;
				case ItemType.Repair: // Value 1 = Repair Amount | Value 2 = none
					ownedVehicle = VehicleService.VehicleService.OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 2);
					if (ownedVehicle == null)
					{
						API.shared.sendNotificationToPlayer(player.Character.Player, "~r~Can't find any Vehicle..");
						return false;
					}
					API.shared.playPlayerAnimation(client, (int)(AnimationFlags.Loop), "anim@amb@garage@chassis_repair@", "base_amy_skater_01");
					StartUsageTimer(client, player, item, 10);
					break;
				case ItemType.FuelCanister:
					ownedVehicle = VehicleService.VehicleService.OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 2);
					if (ownedVehicle == null)
					{
						API.shared.sendNotificationToPlayer(player.Character.Player, "~r~Can't find any Vehicle..");
						return false;
					}
					API.shared.playPlayerAnimation(client, (int)(AnimationFlags.Loop), "anim@amb@garage@chassis_repair@", "base_amy_skater_01");
					StartUsageTimer(client, player, item, 5);
					break;
				case ItemType.Drug: // Value 1 = DrugType | Value 2 = Intense
					StartUsageTimer(client, player, item, 0);
					break;
			}

			API.shared.triggerClientEvent(client, "Inventory_Success");
			return true;
		}

		public static void GiveItem(Client client, int itemId, int count)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			List<Player> playersaround = new List<Player>();
			API.shared.getPlayersInRadiusOfPlayer(1, client).ForEach(x => {
				if (x.hasData("player"))
				{
					playersaround.Add((Player)x.getData("player"));
				}
			});
			if (playersaround.Any(x => x == player))
			{
				playersaround.Remove(player);
			}
			if (playersaround.Count > 1)
			{
				API.shared.sendNotificationToPlayer(client, "~r~Too many people around you..");
				return;
			}
			if (playersaround.Count < 1)
			{
				API.shared.sendNotificationToPlayer(client, "~r~No one is around you..");
				return;
			}
			Player target = playersaround.FirstOrDefault();
			if (target == null) { API.shared.sendNotificationToPlayer(client, "~r~Ooops something went wrong.."); return; }
			Item item = ItemList.FirstOrDefault(x => x.Id == itemId);
			if (item == null) { return; }
			InventoryItem plrinvitem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == itemId);
			if (plrinvitem == null || plrinvitem.Count <= 0 || count <= 0) { return; }
			if (plrinvitem.Count < count) { API.shared.sendNotificationToPlayer(client, "~r~You don't have enough items of this sort in your inventory!"); return; }

			InventoryItem targetinvitem = target.Character.Inventory.FirstOrDefault(x => x.ItemID == itemId);
			if (targetinvitem == null)
			{
				target.Character.Inventory.Add(new InventoryItem
				{
					ItemID = itemId,
					Count = count
				});
			}
			else
			{
				targetinvitem.Count += count;
			}
			API.shared.sendNotificationToPlayer(player.Character.Player, "You give ~b~" + count + "x ~g~" + item.Name + "~w~ away");
			API.shared.sendNotificationToPlayer(target.Character.Player, "You get ~b~" + count + "x ~g~" + item.Name);

			plrinvitem.Count -= count;
			if (plrinvitem.Count <= 0)
			{
				player.Character.Inventory.Remove(plrinvitem);
			}

			CharacterService.CharacterService.UpdateCharacter(player.Character);
			CharacterService.CharacterService.UpdateCharacter(target.Character);
			UpdateInventar(client);
			API.shared.triggerClientEvent(client, "Inventory_Success");
		}

		public static void ThrowAway(Client client, int itemId, int count)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			Item item = ItemList.FirstOrDefault(x => x.Id == itemId);
			if (item == null) { return; }
			InventoryItem plrinvitem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == itemId);
			if (plrinvitem == null || plrinvitem.Count <= 0 || count <= 0) { return; }
			if (plrinvitem.Count < count) { API.shared.sendNotificationToPlayer(client, "~r~You don't have enough items of this sort in your inventory!"); return; }
			plrinvitem.Count -= count;
			if (plrinvitem.Count <= 0)
			{
				player.Character.Inventory.Remove(plrinvitem);
			}
			API.shared.sendNotificationToPlayer(player.Character.Player, "You throw ~b~" + count + "x ~g~" + item.Name + " away");
			UpdateInventar(client);
			API.shared.triggerClientEvent(client, "Inventory_Success");
		}

		public static void UpdateInventar(Client client)
		{
			API.shared.triggerClientEvent(client, "Inventory_Data", JsonConvert.SerializeObject(CharacterService.CharacterService.GetInventoryMenuItems(client)));
		}

		public static void StartUsageTimer(Client client, Player player, Item item, int time)
		{
			if(time <= 0)
			{
				ItemAction(client, player, item);
				return;
			}
			int count = 0;
			InterfaceService.ProgressBarService.ShowBar(client, 0, time, "Use " + item.Name);
			client.setData("usagetimer", API.shared.startTimer(1000, false, () =>
			{
				InterfaceService.ProgressBarService.ChangeProgress(client, count);
				if(count >= time)
				{
					InterfaceService.ProgressBarService.HideBar(client);
					ItemAction(client, player, item);
					API.shared.stopTimer(client.getData("usagetimer"));
					client.resetData("usagetimer");
					API.shared.stopPlayerAnimation(client);
					return;
				}

				count++;
			}));
		}
	}
}
