using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.FactionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Services.CharacterService
{
	class PlayerMenuService
	{

		public static void OpenMenu(Client client)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			if(player.Character.IsCuffed) { return; }
			API.shared.triggerClientEvent(client, "PlayerMenu_Open", JsonConvert.SerializeObject(BuildInteractionMenu(player)));
		}

		#region Player Interaction Menu
		public static List<MenuItem> BuildInteractionMenu(Player player)
		{
			List<MenuItem> menuItemList = new List<MenuItem>();

			#region Seatbelt Menu Item
			if (player.Character.Player.isInVehicle)
			{
				if(player.Character.Player.seatbelt){
					menuItemList.Add(new MenuItem
					{
						Title = "Put off seatbeld",
						Value1 = "toggleseatbelt"
					});
				}else{
					menuItemList.Add(new MenuItem
					{
						Title = "Put seatbelt on",
						Value1 = "toggleseatbelt"
					});
				}
			}
			#endregion Seatbelt Menu Item

			#region Faction Menu Item
			if(player.Character.OnDuty && player.Character.Faction != FactionType.Citizen)
			{
				switch (player.Character.Faction)
				{
					case FactionType.Police:
						menuItemList.AddRange(PoliceService.BuildInteractionMenu(player)); // Add Police Menu Items
						break;
					case FactionType.EMS:
						menuItemList.AddRange(EMSService.BuildInteractionMenu(player)); // Add EMS Menu Items
						break;
				}
			}
			#endregion Faction Menu Item

			#region Inventory Menu Item
			menuItemList.Add(new MenuItem
			{
				Title = "Inventory",
				Value1 = "openinventory"
			});
			#endregion Inventory Menu Item

			#region Handsup
			if (!player.Character.Player.isInVehicle)
			{
				if (player.Character.HasHandsup)
				{
					menuItemList.Add(new MenuItem
					{
						Title = "Hands down",
						Value1 = "togglehandsup"
					});
				}
				else
				{
					menuItemList.Add(new MenuItem
					{
						Title = "Put hands up",
						Value1 = "togglehandsup"
					});
				}
			}
			#endregion Handsup
			return menuItemList;
		}
		#endregion Player Interaction Menu

		public static void CloseMenu(Client client)
		{
			API.shared.triggerClientEvent(client, "PlayerMenu_Close");
		}

		#region PlayerInteraction Menu Processing
		public static void ProcessInteractionMenu(Client client, string itemvalue)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");

			if(player.Character.Faction != FactionType.Citizen)
			{
				switch (player.Character.Faction)
				{
					case FactionType.Police:
						PoliceService.ProcessInteractionMenu(client, itemvalue);
						break;
					case FactionType.EMS:
						EMSService.ProcessInteractionMenu(client, itemvalue);
						break;
				}
			}

			API.shared.triggerClientEvent(client, "PlayerMenu_Close");
			switch (itemvalue)
			{
				#region Seatbelt Menu Item
				case "toggleseatbelt":
					if (!client.isInVehicle) { return; }
					if (client.seatbelt)
					{
						client.seatbelt = false;
						API.shared.sendNotificationToPlayer(client, "Put ~r~off ~w~Seatbelt");
					}
					else
					{
						client.seatbelt = true;
						API.shared.sendNotificationToPlayer(client, "Put ~g~on ~w~Seatbelt");
					}
					break;
				#endregion Seatbelt Menu Item

				case "togglehandsup":
					PoliceService.TogglePlayerHandsup(player);
					break;

				case "openinventory":
					API.shared.triggerClientEvent(client, "Inventory_Open", JsonConvert.SerializeObject(CharacterService.GetInventoryMenuItems(client)));
					break;
			}
		}
		#endregion PlayerInteraction Menu Processing
	}
}
