using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.CharacterService;
using SimpleRoleplay.Server.Services.ClothingService;
using SimpleRoleplay.Server.Services.DoorService;
using SimpleRoleplay.Server.Services.FactionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.FactionHandler
{
	class PoliceHandler 
		: Script
	{
		public PoliceHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
			API.onResourceStart += OnResourceStartHandler;
			API.onResourceStop += OnResourceStopHandler;
		}

		private Ped PoliceWeaponPed = null;
		private Ped PoliceDutyPed = null;

		public void OnResourceStartHandler()
		{
			PoliceWeaponPed = API.createPed(PedHash.Cop01SMY, new Vector3(454.146, -980.071, 30.68959), 84.72414f);
			PoliceDutyPed = API.createPed(PedHash.Cop01SMY, new Vector3(460.1322, -990.9448, 30.6896), 80.99126f);
		}

		public void OnResourceStopHandler()
		{
			if(PoliceWeaponPed != null)
			{
				API.deleteEntity(PoliceWeaponPed);
				PoliceWeaponPed = null;
			}

			if (PoliceDutyPed != null)
			{
				API.deleteEntity(PoliceDutyPed);
				PoliceDutyPed = null;
			}
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments)
		{
			switch (eventName)
			{
				case "KeyboardKey_E_Pressed":
					if (!client.hasData("player")) { return; }
					Player player = client.getData("player");
					if (player.Character.Faction == FactionType.Police)
					{
						CheckDoors(client, player); // Check for Doors

						if(client.position.DistanceTo(new Vector3(452.3879, -980.1114, 30.6896)) <= 1.3f)
						{
							PoliceService.OpenWeaponMenu(client);
						}
					}
					break;
				case "Police_WeaponMenuItemSelected":
					PoliceService.ProcessWeaponMenu(client, (string)arguments[0]);
					break;
			}
		}

		#region Check Doors
		private void CheckDoors(Client client, Player player)
		{
			if (client.position.DistanceTo(new Vector3(460.1322, -990.9448, 30.6896)) <= 2)
			{


				if (client.hasSyncedData("onduty"))
				{
					PoliceService.SetOnDuty(client, false);
				}
				else
				{
					PoliceService.SetOnDuty(client, true);
				}
				return;

			}

			if (client.position.DistanceTo(new Vector3(434.6926, -981.8649, 30.71322)) <= 1) // Mission Row Main Doors
			{
				DoorService.ToggleDoorState(19);
				if (DoorService.ToggleDoorState(18))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				return;
			}

			if (client.position.DistanceTo(new Vector3(464.3711, -983.8344, 43.69287)) <= 1) // Mission Row Top Door
			{
				if (DoorService.ToggleDoorState(27))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				return;
			}

			if (client.position.DistanceTo(new Vector3(463.7195, -992.5253, 24.91487)) <= 1) // Mission Row Main Cell Door
			{
				if (DoorService.ToggleDoorState(26))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				return;
			}

			if (client.position.DistanceTo(new Vector3(464.1983, -1003.415, 24.91487)) <= 1) // Mission Row Back Cell Door (Not Working)
			{
				if (DoorService.ToggleDoorState(20))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				return;
			}

			if (client.position.DistanceTo(new Vector3(462.0896, -993.7011, 24.91486)) <= 1) // Mission Row Cell Door Right
			{
				if (!player.Character.OnDuty) { return; }
				if (DoorService.ToggleDoorState(23))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				return;
			}

			if (client.position.DistanceTo(new Vector3(462.0993, -998.6472, 24.91486)) <= 1) // Mission Row Cell Door Middle
			{
				if (!player.Character.OnDuty) { return; }
				if (DoorService.ToggleDoorState(24))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				return;
			}

			if (client.position.DistanceTo(new Vector3(462.2214, -1002.128, 24.91486)) <= 1) // Mission Row Cell Door Left
			{
				if (!player.Character.OnDuty) { return; }
				if (DoorService.ToggleDoorState(25))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				return;
			}

			if (client.position.DistanceTo(new Vector3(468.6248, -1014.067, 26.38638)) <= 1) // Mission Row Back Doors
			{
				if (DoorService.ToggleDoorState(20))
				{
					API.sendNotificationToPlayer(client, "~r~Locked ~w~Door");
				}
				else
				{
					API.sendNotificationToPlayer(client, "~g~Unlocked ~w~Door");
				}
				DoorService.ToggleDoorState(21);
				return;
			}
			return;
		}
		#endregion Check Doors
	}
}