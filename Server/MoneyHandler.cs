using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.MoneyService;
using System;
using System.Linq;

namespace SimpleRoleplay.Server
{
	class MoneyHandler 
        : Script
	{
		public MoneyHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments) //arguments param can contain multiple params
		{
			
			switch (eventName)
			{
			    case "KeyboardKey_E_Pressed":
			        if (!client.isInVehicle)
			        {
			            if (client.hasData("player"))
			            {
			                ATM atm = ATMService.ATMList.FirstOrDefault(x => x.Position.DistanceTo(client.position) <= 1);
			                if (atm != null)
			                {
			                    OpenATM(client);
			                    API.sendChatMessageToPlayer(client, "ATM with ID: ~y~" + atm.Id + " ~w~found");
			                }
			            }
			        }
			        break;
			    case "ATM_Withdraw":
			        if (MoneyService.HasPlayerEnoughBank(client, Convert.ToDouble(arguments[0])))
			        {
			            MoneyService.WithdrawMoney(client, Convert.ToDouble(arguments[0]));
			            API.sendNotificationToPlayer(client, "~g~" + arguments[0] + " $~w~ was withdrawn from the account.");
			            API.triggerClientEvent(client, "ATM_CloseMenu");
			        }
			        else
			        {
			            API.sendNotificationToPlayer(client, "~r~You don't have enough money on your account.");
			        }
			        break;
			    case "ATM_Deposit":
			        if (MoneyService.HasPlayerEnoughCash(client, Convert.ToDouble(arguments[0])))
			        {
			            MoneyService.DepositMoney(client, Convert.ToDouble(arguments[0]));
			            API.sendNotificationToPlayer(client, "There were ~g~" + arguments[0] + " $~w~ added to your account.");
			            API.triggerClientEvent(client, "ATM_CloseMenu");
			        }
			        else
			        {
			            API.sendNotificationToPlayer(client, "~r~You don't have enough money at your wallet.");
			        }
			        break;
			}
		}

		public void OpenATM(Client client)
		{
			// Open ATM Menu
			Player player = client.getData("player");
			API.triggerClientEvent(client, "ATM_OpenMenu", player.Character.Bank);
		}
	}
}
