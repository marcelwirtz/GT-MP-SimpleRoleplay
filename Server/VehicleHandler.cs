using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.VehicleService;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace SimpleRoleplay.Server
{
	class VehicleHandler 
		: Script
	{
		public VehicleHandler()
		{
			API.onResourceStart += OnResourceStartHandler;
			API.onResourceStop += OnResourceStopHandler;
			API.onClientEventTrigger += OnClientEvent;
		}
		public Timer Vehicletimer = null;

		public void OnResourceStartHandler()
		{
			Vehicletimer = API.startTimer(60000, false, () => 
			{
				VehicleService.OwnedVehicleList.ForEach(ownedVehicle =>
				{
					if (ownedVehicle.ActiveHandle.engineStatus)
					{
						ownedVehicle.Fuel--;
						if (ownedVehicle.Fuel < 0)
							ownedVehicle.Fuel = 0;
						if (ownedVehicle.Fuel > 100)
							ownedVehicle.Fuel = 100; // Max Fuel 100
						ownedVehicle.ActiveHandle.setSyncedData("fuel", ownedVehicle.Fuel);
						if (ownedVehicle.Fuel == 0)
							//ownedVehicle.ActiveHandle.fuelLevel = 0;
						VehicleService.UpdateVehicle(ownedVehicle);
					}
				});
			});
		}

		public void OnResourceStopHandler()
		{
			API.stopTimer(Vehicletimer);
			Vehicletimer = null;
			VehicleService.OwnedVehicleList.ForEach(ownedVehicle =>
			{
				API.deleteEntity(ownedVehicle.ActiveHandle);
				VehicleService.OwnedVehicleList.Remove(ownedVehicle);
			});
			VehicleService.OwnedVehicleList.Clear();
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments) //arguments param can contain multiple params
		{
			Player player = null;
			OwnedVehicle ownedVehicle = null;

			switch (eventName)
			{
				case "KeyboardKey_U_Pressed":
					if (!client.hasData("player"))
						return;
					player = client.getData("player");
					ownedVehicle = VehicleService.OwnedVehicleList.FirstOrDefault(x => x.Owner == client.socialClubName && x.OwnerCharId == player.Character.Id && x.ActiveHandle.position.DistanceTo(client.position) <= 4f);
					if (ownedVehicle == null)
						return;
					if (ownedVehicle.ActiveHandle.locked)
					{
						ownedVehicle.ActiveHandle.locked = false;
						API.sendNotificationToPlayer(client, "The vehicle doors of your ~b~" + ownedVehicle.ModelName + " ~w~are now ~g~unlocked");
					}
					else
					{
						ownedVehicle.ActiveHandle.locked = true;
						API.sendNotificationToPlayer(client, "The vehicle doors of your ~b~" + ownedVehicle.ModelName + "~w~ are now ~r~locked");
					}
					break;
				case "KeyboardKey_Z_Pressed":
					if (!client.isInVehicle)
						return;
					if (API.shared.getPlayerVehicleSeat(client) != -1)
						return;
					if (!client.hasData("player"))
						return;
					if (!client.vehicle.hasData("vehicle"))
						return;
					player = client.getData("player");
					ownedVehicle = client.vehicle.getData("vehicle");
					if(client.socialClubName.ToLower() == ownedVehicle.Owner.ToLower() && player.Character.Id == ownedVehicle.OwnerCharId)
					{
						if (client.vehicle.engineStatus)
						{
							client.vehicle.engineStatus = false;
							API.shared.sendNotificationToPlayer(client, "Vehicle engine switched ~r~off");
						}
						else
						{
							if(ownedVehicle.Fuel <= 0) { return; }
							if(ownedVehicle.ActiveHandle.engineHealth <= 0) { return; }
							client.vehicle.engineStatus = true;
							API.shared.sendNotificationToPlayer(client, "Vehicle engine switched ~g~on");
						}
					}
					else
					{
						API.shared.sendNotificationToPlayer(client, "~r~You are not the Owner of this vehicle!");
					}
					break;
				case "KeyboardKey_K_Pressed":
					if (!client.hasData("player"))
						return;
					player = client.getData("player");
					if (client.isInVehicle)
					{
						if (!client.vehicle.hasData("vehicle")) { return; }
						ownedVehicle = client.vehicle.getData("vehicle");
					}
					else
					{
						ownedVehicle = VehicleService.OwnedVehicleList.FirstOrDefault(x => x.ActiveHandle.position.DistanceTo(client.position) <= 4f);
					}
					if (ownedVehicle == null)
						return;
					List<MenuItem> vehMenu = VehicleService.BuildVehicleMenu(player, ownedVehicle);
					if(vehMenu == null) { return; }
					API.triggerClientEvent(client, "Vehicle_OpenMenu", JsonConvert.SerializeObject(vehMenu));
					break;
				case "Vehicle_MainMenuItemSelected":
					VehicleService.ProcessVehicleMenuReturn(client, (string)arguments[0]);
					break;
				case "Vehicle_InventoryMenuItemSelected":
					if((int)arguments[1] <= 0) { return; }
					VehicleService.PutOutOfVehicleInventory(client, (int)arguments[0], (int)arguments[1]);
					break;
				case "Vehicle_PlayerInventoryMenuItemSelected":
					if ((int)arguments[1] <= 0) { return; }
					VehicleService.PutIntoVehicleInventory(client, (int)arguments[0], (int)arguments[1]);
					break;
				case "Vehicle_CloseTrunk":
					VehicleService.ChangeDoorState(client, 5, false);
					break;
			}
		}
	}
}
