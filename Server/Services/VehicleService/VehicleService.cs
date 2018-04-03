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

namespace SimpleRoleplay.Server.Services.VehicleService
{
	class VehicleService
	{
		public static readonly List<OwnedVehicle> OwnedVehicleList = new List<OwnedVehicle>();

		#region Vehicle Informations
		public static readonly List<VehicleInfo> VehicleData = new List<VehicleInfo>();

		public static void LoadVehicleInformationsFromDB()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM vehicleinfo", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					VehicleInfo vehicleInfo = new VehicleInfo
					{
						Id = (int)row["Id"],
						Model = (string)row["Model"],
						DisplayName = (string)row["DisplayName"],
						MaxFuel = (int)row["MaxFuel"],
						Fuel = (FuelType)row["Fuel"],
						MaxStorage = (int)row["MaxStorage"],
						Type = (VehicleType)row["Type"]
					};
					VehicleData.Add(vehicleInfo);
				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Vehicle Informations Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No Vehicle Informations Loaded..");
			}
		}

		public static VehicleInfo GetVehicleInfo(string modelName)
		{
			return VehicleData.FirstOrDefault(info => info.Model.ToLower() == modelName.ToLower());				
		}
		#endregion Vehicle Informations

		public static void CreateNewVehicle(OwnedVehicle ownedVehicle)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Owner", ownedVehicle.Owner },
				{ "@OwnerCharId", ownedVehicle.OwnerCharId.ToString() },
				{ "@Model", ownedVehicle.ModelName },
				{ "@EngineHealth", ownedVehicle.EngineHealth.ToString() },
				{ "@Fuel", ownedVehicle.Fuel.ToString() },
				{ "@Faction", ((int)ownedVehicle.Faction).ToString() },
				{ "@NumberPlate", ownedVehicle.NumberPlate },
				{ "@PrimaryColor", ownedVehicle.PrimaryColor.ToString() },
				{ "@SecondaryColor", ownedVehicle.SecondaryColor.ToString() },
				{ "@Livery", ownedVehicle.Livery.ToString() },
				{ "@Inventory", JsonConvert.SerializeObject(ownedVehicle.Inventory) }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO ownedvehicles (Owner, OwnerCharId, Model, EngineHealth, Fuel, Faction, NumberPlate, PrimaryColor, SecondaryColor," +
				" Inventory, Livery) " +
				"VALUES (@Owner, @OwnerCharId, @Model, @EngineHealth, @Fuel, @Faction, @NumberPlate, @PrimaryColor, @SecondaryColor, @Inventory, @Livery)", parameters);
		}

		public static void UpdateVehicle(OwnedVehicle ownedVehicle)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", ownedVehicle.Id.ToString() },
				{ "@Owner", ownedVehicle.Owner },
				{ "@Model", ownedVehicle.Model.ToString() },
				{ "@EngineHealth", ownedVehicle.ActiveHandle.engineHealth.ToString() },
				{ "@Fuel", ownedVehicle.Fuel.ToString() },
				{ "@Faction", ownedVehicle.Faction.ToString() },
				{ "@NumberPlate", ownedVehicle.NumberPlate },
				{ "@PrimaryColor", ownedVehicle.PrimaryColor.ToString() },
				{ "@SecondaryColor", ownedVehicle.SecondaryColor.ToString() },
				{ "@Livery", ownedVehicle.Livery.ToString() },
				{ "@Inventory", JsonConvert.SerializeObject(ownedVehicle.Inventory) }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE ownedvehicles SET Owner = @Owner, EngineHealth = @EngineHealth, Fuel = @Fuel, NumberPlate = @NumberPlate," +
				" PrimaryColor = @PrimaryColor, SecondaryColor = @SecondaryColor, Inventory = @Inventory, Livery = @Livery WHERE Id = @Id LIMIT 1", parameters);
		}

		public static OwnedVehicle LoadFromDatabase(int id)
		{
			OwnedVehicle ownedVehicle = null;

			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@Id", id.ToString()}
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM ownedvehicles WHERE Id = @Id LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					ownedVehicle = new OwnedVehicle
					{
						Id = (int) row["Id"],
						Owner = (string) row["Owner"],
						OwnerCharId = (int) row["OwnerCharId"],
						Model = API.shared.getHashKey((string) row["Model"]),
						ModelName = (string) row["Model"],
						EngineHealth = (int) row["EngineHealth"],
						Fuel = (int) row["Fuel"],
						Faction = (FactionType) ((int) row["Faction"]),
						NumberPlate = (string) row["NumberPlate"],
						PrimaryColor = (int) row["PrimaryColor"],
						SecondaryColor = (int) row["SecondaryColor"],
						Livery = (int)row["Livery"],
						InUse = Convert.ToBoolean((int) row["InUse"]),
						Inventory = JsonConvert.DeserializeObject<List<InventoryItem>>((string)row["Inventory"])
				};
				}
			}
			return ownedVehicle;
		}

		public static void SetInUse(OwnedVehicle ownedVehicle, bool inUse)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", ownedVehicle.Id.ToString() },
				{ "@InUse", Convert.ToInt32(inUse).ToString() }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE ownedvehicles SET InUse = @InUse WHERE Id = @Id LIMIT 1", parameters);
		}

		public static void ResetAllVehicles()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE ownedvehicles SET InUse = 0", parameters);
		}

		public static List<OwnedVehicle> GetUserVehicles(Client client, bool inUse = false)
		{
			if (!client.hasData("player"))
				return null;
			Player player = client.getData("player");
			List<OwnedVehicle> vehicles = new List<OwnedVehicle>();
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@Owner", client.socialClubName},
				{"@OwnerCharId", player.Character.Id.ToString()},
				{"@InUse", Convert.ToInt32(inUse).ToString()}
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM ownedvehicles WHERE Owner = @Owner AND OwnerCharId = @OwnerCharId AND InUse = @InUse", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					vehicles.Add(new OwnedVehicle
					{
						Id = (int)row["Id"],
						Owner = (string)row["Owner"],
						OwnerCharId = (int)row["OwnerCharId"],
						Model = API.shared.getHashKey((string)row["Model"]),
						ModelName = (string)row["Model"],
						EngineHealth = (int)row["EngineHealth"],
						Fuel = (int)row["Fuel"],
						Faction = (FactionType)((int)row["Faction"]),
						NumberPlate = (string)row["NumberPlate"],
						PrimaryColor = (int)row["PrimaryColor"],
						SecondaryColor = (int)row["SecondaryColor"],
						Livery = (int)row["Livery"],
						InUse = Convert.ToBoolean((int)row["InUse"])
					});
				}
			}

			return vehicles;
		}

		#region Vehicle Inventory
		public static void RequestVehicleInventory(Client client, OwnedVehicle ownedVehicle)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			List<InventoryMenuItem> VehicleInventoryMenuItems = new List<InventoryMenuItem>();
			ownedVehicle.Inventory.ForEach(invItem => {
			Item item = ItemService.ItemService.ItemList.FirstOrDefault(x => x.Id == invItem.ItemID);
				if (item != null)
				{
					VehicleInventoryMenuItems.Add(new InventoryMenuItem
					{
						Id = item.Id,
						Name = item.Name,
						Description = item.Description,
						Count = invItem.Count
					});
				}
			});
			API.shared.triggerClientEvent(client, "Vehicle_UpdateInventory", JsonConvert.SerializeObject(VehicleInventoryMenuItems));
		}

		public static void RequestPlayerInventory(Client client)
		{
			List<InventoryMenuItem> inventoryMenuList = new List<InventoryMenuItem>();
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			if (player.Character.Inventory.Count != 0)
			{
				player.Character.Inventory.ForEach(inventoryItem =>
				{
					Item item = ItemService.ItemService.ItemList.FirstOrDefault(x => x.Id == inventoryItem.ItemID);
					if (item != null)
					{
						inventoryMenuList.Add(new InventoryMenuItem
						{
							Id = item.Id,
							Name = item.Name,
							Description = item.Description,
							Count = inventoryItem.Count
						});
					}
				});
			}
			API.shared.triggerClientEvent(client, "Vehicle_UpdatePlayerInventory", JsonConvert.SerializeObject(inventoryMenuList));
		}
		#endregion Vehicle Inventory

		#region Menu Builder
		public static List<MenuItem> BuildVehicleMenu(Player player, OwnedVehicle ownedVehicle)
		{
			List<MenuItem> menuItemList = new List<MenuItem>();

			bool hasAccess = false;
			if(ownedVehicle.Owner == player.Character.Player.socialClubName && ownedVehicle.OwnerCharId == player.Character.Id) { hasAccess = true; }
			if(ownedVehicle.ActiveHandle.locked == true && hasAccess == false) { return null; }
			if (player.Character.Player.isInVehicle)
			{
				if(player.Character.Player.vehicleSeat == -1)
				{
					if (ownedVehicle.ActiveHandle.engineStatus)
					{
						menuItemList.Add(new MenuItem
						{
							Title = "Turn engine off",
							Value1 = "enginestatus"
						});
					}
					else
					{
						menuItemList.Add(new MenuItem
						{
							Title = "Turn engine on",
							Value1 = "enginestatus"
						});
					}
				}
			}
			if (hasAccess)
			{
				if (ownedVehicle.ActiveHandle.locked)
				{
					menuItemList.Add(new MenuItem
					{
						Title = "Unlock the vehicle",
						Value1 = "lockstatus"
					});
				}
				else
				{
					menuItemList.Add(new MenuItem
					{
						Title = "Lock the vehicle",
						Value1 = "lockstatus"
					});
				}
			}
			if (!player.Character.Player.isInVehicle)
			{
				menuItemList.Add(new MenuItem
				{
					Title = "Put out of the trunk",
					Value1 = "trunkputout"
				});
				menuItemList.Add(new MenuItem
				{
					Title = "Put into the trunk",
					Value1 = "trunkputin"
				});
			}
			return menuItemList;
		}

		public static void ProcessVehicleMenuReturn(Client client, string menuValue)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			OwnedVehicle ownedVehicle = null;
			if (client.isInVehicle)
			{
				if (!client.vehicle.hasData("vehicle")) { return; }
				ownedVehicle = client.vehicle.getData("vehicle");
			}
			else
			{
				ownedVehicle = OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 4f);
			}
			if (ownedVehicle == null)
				return;
			bool hasAccess = false;
			if (ownedVehicle.Owner == player.Character.Player.socialClubName && ownedVehicle.OwnerCharId == player.Character.Id) { hasAccess = true; }
			switch (menuValue)
			{
				case "enginestatus":
					if (!client.isInVehicle) { return; }
					if(client.vehicleSeat != -1) { return; }
					if (!hasAccess) { return; }
					if (client.vehicle.engineStatus)
					{
						client.vehicle.engineStatus = false;
						API.shared.sendNotificationToPlayer(client, "Vehicle engine switched ~r~off");
					}
					else
					{
                        if(ownedVehicle.Fuel <= 0)
                        {
                            ownedVehicle.ActiveHandle.engineStatus = false;
                            return;
                        }
						client.vehicle.engineStatus = true;
						API.shared.sendNotificationToPlayer(client, "Vehicle engine switched ~g~on");
					}
					CloseVehicleMenu(client);
					break;
				case "lockstatus":
					if (!hasAccess) { return; }
					if (ownedVehicle.ActiveHandle.locked)
					{
						ownedVehicle.ActiveHandle.locked = false;
						API.shared.sendNotificationToPlayer(client, "The vehicle doors of your ~b~" + ownedVehicle.ModelName + " ~w~are now ~g~unlocked");
					}
					else
					{
						ownedVehicle.ActiveHandle.locked = true;
						API.shared.sendNotificationToPlayer(client, "The vehicle doors of your ~b~" + ownedVehicle.ModelName + "~w~ are now ~r~locked");
					}
					CloseVehicleMenu(client);
					break;
				case "trunkputout":
					if (ownedVehicle.ActiveHandle.locked == true && hasAccess == false) { return; }
					if (client.isInVehicle) return;
					RequestVehicleInventory(client, ownedVehicle);
					API.shared.triggerClientEvent(client, "Vehicle_OpenInventory");
					ownedVehicle.ActiveHandle.openDoor(5);
					break;
				case "trunkputin":
					if (client.isInVehicle) return;
					if (ownedVehicle.ActiveHandle.locked == true && hasAccess == false) { return; }
					RequestPlayerInventory(client);
					API.shared.triggerClientEvent(client, "Vehicle_OpenPlayerInventory");
					ownedVehicle.ActiveHandle.openDoor(5);
					break;
			}
		}

		public static void CloseVehicleMenu(Client client)
		{
			API.shared.triggerClientEvent(client, "Vehicle_CloseAllMenus");
		}
		#endregion Menu Builder

		public static void PutOutOfVehicleInventory(Client client, int itemId, int count)
		{
			if (client.isInVehicle) return;
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			OwnedVehicle ownedVehicle = null;
			if (client.isInVehicle)
			{
				if (!client.vehicle.hasData("vehicle")) { return; }
				ownedVehicle = client.vehicle.getData("vehicle");
			}
			else
			{
				ownedVehicle = OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 4f);
			}
			if (ownedVehicle == null)
				return;
			bool hasAccess = false;
			if (ownedVehicle.Owner == player.Character.Player.socialClubName && ownedVehicle.OwnerCharId == player.Character.Id) { hasAccess = true; }
			if (ownedVehicle.ActiveHandle.locked == true && hasAccess == false) { return; }
			Item item = ItemService.ItemService.ItemList.FirstOrDefault(x => x.Id == itemId);
			if (item == null) { return; }
			InventoryItem invitem = ownedVehicle.Inventory.FirstOrDefault(x => x.ItemID == itemId);
			if(invitem == null || invitem.Count <= 0 || count <= 0) { return; }
			if(invitem.Count < count) {API.shared.sendNotificationToPlayer(client, "~r~You don't have enough items of this sort in your vehicle!"); return; }
			InventoryItem plrinvitem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == itemId);
			if(plrinvitem == null)
			{
				player.Character.Inventory.Add(new InventoryItem
				{
					ItemID = itemId,
					Count = count
				});
			}
			else
			{
				plrinvitem.Count += count;
			}
			invitem.Count -= count;
			if(invitem.Count <= 0)
			{
				ownedVehicle.Inventory.Remove(invitem);
			}
			UpdateVehicle(ownedVehicle);
			CharacterService.CharacterService.UpdateCharacter(player.Character);
			API.shared.sendNotificationToPlayer(client, "You taken ~b~" + count + "~w~x ~g~" + item.Name + "~w~ out of the vehicle trunk.");
			RequestVehicleInventory(client, ownedVehicle);

		}

		public static void PutIntoVehicleInventory(Client client, int itemId, int count)
		{
			if (client.isInVehicle) return;
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			OwnedVehicle ownedVehicle = null;
			if (client.isInVehicle)
			{
				if (!client.vehicle.hasData("vehicle")) { return; }
				ownedVehicle = client.vehicle.getData("vehicle");
			}
			else
			{
				ownedVehicle = OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 4f);
			}
			if (ownedVehicle == null)
				return;
			bool hasAccess = false;
			if (ownedVehicle.Owner == player.Character.Player.socialClubName && ownedVehicle.OwnerCharId == player.Character.Id) { hasAccess = true; }
			if (ownedVehicle.ActiveHandle.locked == true && hasAccess == false) { return; }
			Item item = ItemService.ItemService.ItemList.FirstOrDefault(x => x.Id == itemId);
			if (item == null) { return; }
			InventoryItem plrinvitem = player.Character.Inventory.FirstOrDefault(x => x.ItemID == itemId);
			if (plrinvitem == null || plrinvitem.Count <= 0 || count <= 0) { return; }
			if (plrinvitem.Count < count) { API.shared.sendNotificationToPlayer(client, "~r~You don't have enough items of this sort in your inventory!"); return; }


			InventoryItem invitem = ownedVehicle.Inventory.FirstOrDefault(x => x.ItemID == itemId);
			if (invitem == null)
			{
				ownedVehicle.Inventory.Add(new InventoryItem
				{
					ItemID = itemId,
					Count = count
				});
			}
			else
			{
				invitem.Count += count;
			}
			plrinvitem.Count -= count; 
			if (plrinvitem.Count <= 0) 
			{
				player.Character.Inventory.Remove(plrinvitem); 
			}
			UpdateVehicle(ownedVehicle);
			CharacterService.CharacterService.UpdateCharacter(player.Character);
			API.shared.sendNotificationToPlayer(client, "You put ~b~" + count + "~w~x ~g~" + item.Name + "~w~ into the vehicle trunk.");
			RequestPlayerInventory(client);
		}

		public static void ChangeDoorState(Client client, int door, bool doorOpen)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			OwnedVehicle ownedVehicle = null;
			if (client.isInVehicle)
			{
				if (!client.vehicle.hasData("vehicle")) { return; }
				ownedVehicle = client.vehicle.getData("vehicle");
			}
			else
			{
				ownedVehicle = OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 4f);
			}
			if (ownedVehicle == null)
				return;
			bool hasAccess = false;
			if (ownedVehicle.Owner == player.Character.Player.socialClubName && ownedVehicle.OwnerCharId == player.Character.Id) { hasAccess = true; }
			if (ownedVehicle.ActiveHandle.locked == true && hasAccess == false) { return; }
			if (doorOpen)
			{
				ownedVehicle.ActiveHandle.openDoor(door);
			}
			else
			{
				ownedVehicle.ActiveHandle.closeDoor(door);
			}
		}
	}
}
