using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Timers;

namespace SimpleRoleplay.Server.Services.VehicleService
{
	class GasStationService
	{
		public static readonly List<GasStation> GasStationList = new List<GasStation>();

		public static void LoadAllGasStationsFromDB()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM gasstations", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					GasStation gasStation = new GasStation
					{
						Id = (int)row["Id"],
						Position = new Vector3((float)row["PosX"], (float)row["PosY"], (float)row["PosZ"]),
						GasPumps = JsonConvert.DeserializeObject<List<Vector3>>((string)row["GasPumps"]),
						StationFuelPrices = JsonConvert.DeserializeObject<FuelPrices>((string)row["FuelPrices"]),
						Storage = JsonConvert.DeserializeObject<FuelStorage>((string)row["Storage"]),
						MoneyStorage = (double)row["MoneyStorage"]
					};
					gasStation.MapMarker = API.shared.createBlip(gasStation.Position);
					gasStation.MapMarker.shortRange = true;
					gasStation.MapMarker.sprite = 361;
					gasStation.MapMarker.scale = 0.75f;
					GasStationList.Add(gasStation);
					BlipService.BlipService.BlipList.Add(gasStation.MapMarker);
				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Gas Stations Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No Gas Stations Loaded..");
			}
		}

		public static void UpdateGasStation(GasStation gasStation)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", gasStation.Id.ToString() },
				{ "@GasPumps", JsonConvert.SerializeObject(gasStation.GasPumps) },
				{ "@FuelPrices", JsonConvert.SerializeObject(gasStation.StationFuelPrices) },
				{ "@Storage", JsonConvert.SerializeObject(gasStation.Storage) },
				{ "@MoneyStorage", gasStation.MoneyStorage.ToString() }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE gasstations SET GasPumps = @GasPumps, FuelPrices = @FuelPrices, Storage = @Storage, " +
				"MoneyStorage = @MoneyStorage WHERE Id = @Id LIMIT 1", parameters);
		}

		public static void SaveGasPumps(GasStation gasStation)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", gasStation.Id.ToString() },
				{ "@GasPumps", JsonConvert.SerializeObject(gasStation.GasPumps) }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE gasstations SET GasPumps = @GasPumps WHERE Id = @Id LIMIT 1", parameters);
		}

		public static void AddGasPump(int gasstationId, Vector3 position)
		{
			GasStation gasStation = GasStationList.FirstOrDefault(x => x.Id == gasstationId);
			if (gasStation == null)
				return;
			gasStation.GasPumps.Add(position);
			SaveGasPumps(gasStation);
		}

		public static void AddGasPump(int gasstationId, Client client)
		{
			GasStation gasStation = GasStationList.FirstOrDefault(x => x.Id == gasstationId);
			if (gasStation == null)
				return;
			gasStation.GasPumps.Add(client.position);
			SaveGasPumps(gasStation);
		}

		public static void AddGasStation(Vector3 position, double heading)
		{
			GasStation gasStation = new GasStation();
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", position.X.ToString().Replace(",", ".") },
				{ "@PosY", position.Y.ToString().Replace(",", ".") },
				{ "@PosZ", position.Z.ToString().Replace(",", ".") },
				{ "@GasPumps", JsonConvert.SerializeObject(gasStation.GasPumps) },
				{ "@FuelPrices", JsonConvert.SerializeObject(gasStation.StationFuelPrices) },
				{ "@Storage", JsonConvert.SerializeObject(gasStation.Storage) }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO gasstations (PosX, PosY, PosZ, GasPumps, FuelPrices, Storage) " +
				"VALUES (@PosX, @PosY, @PosZ, @GasPumps, @FuelPrices, @Storage)", parameters);
		}

		public static void AddGasStation(Client client)
		{
			GasStation gasStation = new GasStation();
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", client.position.X.ToString().Replace(",", ".") },
				{ "@PosY", client.position.Y.ToString().Replace(",", ".") },
				{ "@PosZ", client.position.Z.ToString().Replace(",", ".") },
				{ "@GasPumps", JsonConvert.SerializeObject(gasStation.GasPumps) },
				{ "@FuelPrices", JsonConvert.SerializeObject(gasStation.StationFuelPrices) },
				{ "@Storage", JsonConvert.SerializeObject(gasStation.Storage) }
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO gasstations (PosX, PosY, PosZ, GasPumps, FuelPrices, Storage) " +
				"VALUES (@PosX, @PosY, @PosZ, @GasPumps, @FuelPrices, @Storage)", parameters);
		}

		public static void ReloadGasStations()
		{
			GasStationList.ForEach(gasStation =>
			{
				if (gasStation.MapMarker != null)
					API.shared.deleteEntity(gasStation.MapMarker);
			});
			GasStationList.Clear();
			LoadAllGasStationsFromDB();
		}

		public static void OpenGasStationMenu(Client client)
		{
			if(!client.hasData("player")) { return; }
			Player player = client.getData("player");
			GasStation gasStation = GasStationList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 20);
			if(gasStation == null) { return; }
			bool foundGasPump = false;
			gasStation.GasPumps.ForEach(pump =>
			{
				if (!foundGasPump)
				{
					if (pump.DistanceTo(client.position) <= 4f)
					{
						foundGasPump = true;
					}
				}
			});

			if (foundGasPump)
			{
				List<GasStationMenuItem> GasMenuList = new List<GasStationMenuItem>();
				GasStationMenuItem gasItem = null;

				// Petrol
				if (gasStation.StationFuelPrices.Petrol != 0)
				{
					gasItem = new GasStationMenuItem
					{
						Name = FuelType.Petrol.ToString(),
						RightLabel = gasStation.StationFuelPrices.Petrol + " ~g~$",
						Ident = (int)FuelType.Petrol
					};
					if (gasStation.Storage.Petrol <= 0) { gasItem.SoldOut = true; } else { gasItem.SoldOut = false; }
					GasMenuList.Add(gasItem);
				}

				// Diesel
				if (gasStation.StationFuelPrices.Diesel != 0)
				{
					gasItem = new GasStationMenuItem
					{
						Name = FuelType.Diesel.ToString(),
						RightLabel = gasStation.StationFuelPrices.Diesel + " ~g~$",
						Ident = (int)FuelType.Diesel
					};
					if (gasStation.Storage.Diesel <= 0) { gasItem.SoldOut = true; } else { gasItem.SoldOut = false; }
					GasMenuList.Add(gasItem);
				}

				// Gas
				if (gasStation.StationFuelPrices.Gas != 0)
				{
					gasItem = new GasStationMenuItem
					{
						Name = FuelType.Gas.ToString(),
						RightLabel = gasStation.StationFuelPrices.Gas + " ~g~$",
						Ident = (int)FuelType.Gas
					};
					if (gasStation.Storage.Gas <= 0) { gasItem.SoldOut = true; } else { gasItem.SoldOut = false; }
					GasMenuList.Add(gasItem);
				}

				// Electricity
				if (gasStation.StationFuelPrices.Electricity != 0)
				{
					gasItem = new GasStationMenuItem
					{
						Name = FuelType.Electricity.ToString(),
						RightLabel = gasStation.StationFuelPrices.Electricity + " ~g~$",
						Ident = (int)FuelType.Electricity
					};
					gasItem.SoldOut = false; // Electricity is always available
					GasMenuList.Add(gasItem);
				}

				// Kerosene
				if (gasStation.StationFuelPrices.Kerosene != 0)
				{
					gasItem = new GasStationMenuItem
					{
						Name = FuelType.Kerosene.ToString(),
						RightLabel = gasStation.StationFuelPrices.Kerosene + " ~g~$",
						Ident = (int)FuelType.Kerosene
					};
					if (gasStation.Storage.Kerosene <= 0) { gasItem.SoldOut = true; } else { gasItem.SoldOut = false; }
					GasMenuList.Add(gasItem);
				}


				// Vehicle in radius
				List<GarageMenuItem> vehiclemenu = new List<GarageMenuItem>();
				VehicleService.OwnedVehicleList.Where(x => x.ActiveHandle.position.DistanceTo(client.position) <= 8f).ToList().ForEach(ownedVehicle => {
					vehiclemenu.Add(new GarageMenuItem {
						Id = ownedVehicle.Id,
						ModelName = ownedVehicle.ModelName,
						NumberPlate = ownedVehicle.NumberPlate
					});
				});

				API.shared.triggerClientEvent(client, "GasStation_OpenMenu", JsonConvert.SerializeObject(GasMenuList), JsonConvert.SerializeObject(vehiclemenu));
			}
		}

		public static void CloseMenu(Client client)
		{
			API.shared.triggerClientEvent(client, "GasStation_CloseMenu");
		}

		public static void StartRefill(Client client, OwnedVehicle ownedVehicle, FuelType fuelType)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			if (ownedVehicle.ActiveHandle.engineStatus)
			{
				API.shared.sendNotificationToPlayer(client, "~r~You must first turn off the engine before you start refuel.");
				return;
			}
			GasStation gasStation = GasStationList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 20);
			client.setData("gasStation", gasStation);
			if(gasStation == null) { return; }

			if (VehicleService.GetVehicleInfo(ownedVehicle.ModelName).Fuel != fuelType)
			{
				API.shared.sendNotificationToPlayer(client, "~o~You don't wont fill " + fuelType.ToString() + " in your " + ownedVehicle.ModelName + "(" +
					VehicleService.GetVehicleInfo(ownedVehicle.ModelName).Fuel.ToString() + ").. ~r~~n~Remember that..");
				return;
			}

			int maxFuel = VehicleService.GetVehicleInfo(ownedVehicle.ModelName).MaxFuel;
			int startFuel = ownedVehicle.Fuel;
			double price = 0;
			switch (fuelType)
			{
				case FuelType.Petrol:
					price = gasStation.StationFuelPrices.Petrol;
					break;
				case FuelType.Diesel:
					price = gasStation.StationFuelPrices.Diesel;
					break;
				case FuelType.Gas:
					price = gasStation.StationFuelPrices.Gas;
					break;
				case FuelType.Electricity:
					price = gasStation.StationFuelPrices.Electricity;
					break;
				case FuelType.Kerosene:
					price = gasStation.StationFuelPrices.Kerosene;
					break;
			}

			API.shared.triggerClientEvent(client, "ShowRefuelProgressbar", ownedVehicle.Fuel, maxFuel);
			client.setData("fuelStartPosition", client.position);
			client.setSyncedData("currentfuel", ownedVehicle.Fuel);
			client.setData("fuelcar", ownedVehicle);
			client.setData("fuelcarstart", ownedVehicle.Fuel);
			client.setData("fueltype", fuelType);
			Timer timer = API.shared.startTimer(1000, false, () => {
				if(ownedVehicle.Fuel < VehicleService.GetVehicleInfo(ownedVehicle.ModelName).MaxFuel)
				{
					Vector3 startPositon = client.getData("fuelStartPosition");
					if(startPositon.DistanceTo(client.position) > 4f)
					{
						StopRefill(client);
						return;
					}

					switch (fuelType)
					{
						case FuelType.Petrol:
							if (gasStation.Storage.Petrol > 0)
							{
								gasStation.Storage.Petrol--;
							}
							else
							{
								StopRefill(client);
								API.shared.sendNotificationToPlayer(client, "~o~This gas station has no more ~b~Petrol~o~ in stock..");
								return;
							}
							break;
						case FuelType.Diesel:
							if (gasStation.Storage.Diesel > 0)
							{
								gasStation.Storage.Diesel--;
							}
							else
							{
								StopRefill(client);
								API.shared.sendNotificationToPlayer(client, "~o~This gas station has no more ~b~Diesel~o~ in stock..");
								return;
							}
							break;
						case FuelType.Gas:
							if (gasStation.Storage.Gas > 0)
							{
								gasStation.Storage.Gas--;
							}
							else
							{
								StopRefill(client);
								API.shared.sendNotificationToPlayer(client, "~o~This gas station has no more ~b~Gas~o~ in stock..");
								return;
							}
							break;
					}

					if(player.Character.Bank < GetFuelPrice(gasStation, fuelType))
					{
						StopRefill(client);
						API.shared.sendNotificationToPlayer(client, "~r~You don't have enough Money to continue the Refuel..");
						return;
					}
					

					ownedVehicle.Fuel++;
					player.Character.Bank -= price;
					gasStation.MoneyStorage += price;
					ownedVehicle.ActiveHandle.setSyncedData("fuel", ownedVehicle.Fuel);
					client.setSyncedData("currentfuel", ownedVehicle.Fuel);

				}
				else
				{
					StopRefill(client);
					
				}
			});
			client.setData("refuelTimer", timer);
		}

		public static void StopRefill(Client client)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			API.shared.triggerClientEvent(client, "HideRefuelProgressbar");
			API.shared.stopTimer((Timer)client.getData("refuelTimer"));
			OwnedVehicle ownedVehicle = client.getData("fuelcar");
			GasStation gasStation = client.getData("gasStation");
			FuelType fuelType = client.getData("fueltype");
			int fuelStart = client.getData("fuelcarstart");
			int fueled = ownedVehicle.Fuel - fuelStart;
			API.shared.sendNotificationToPlayer(client, "~b~Refuel Stopped~n~~w~You paid ~g~" + (fueled * GetFuelPrice(gasStation ,fuelType)) + "$");
			client.resetData("refuelTimer");
			client.resetData("fuelStartPosition");
			client.resetData("fuelcar");
			client.resetData("fuelcarstart");
			client.resetSyncedData("currentfuel");
			UpdateGasStation(gasStation);
			client.resetData("gasStation");
			client.resetData("fueltype");
			CharacterService.CharacterService.UpdateCharacter(player.Character);
		}

		public static double GetFuelPrice(GasStation gasStation, FuelType fuelType)
		{
			double price = 0;
			switch (fuelType)
			{
				case FuelType.Petrol:
					price = gasStation.StationFuelPrices.Petrol;
					break;
				case FuelType.Diesel:
					price = gasStation.StationFuelPrices.Diesel;
					break;
				case FuelType.Gas:
					price = gasStation.StationFuelPrices.Gas;
					break;
				case FuelType.Electricity:
					price = gasStation.StationFuelPrices.Electricity;
					break;
				case FuelType.Kerosene:
					price = gasStation.StationFuelPrices.Kerosene;
					break;
			}
			return price;
		}
	}
}
