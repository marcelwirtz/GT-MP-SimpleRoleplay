using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Services.ClothingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server
{
	class ClothingShopHandler
	: Script
	{
		public ClothingShopHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments)
		{
			switch (eventName)
			{
				case "ClothingShop_Buy":
					ClothingShopService.BuyClothing(client, (string)arguments[0], (int)arguments[1]);
					break;
				case "ClothingShop_Preview":
					ClothingShopService.PreviewClothing(client, (string)arguments[0], (int)arguments[1]);
					break;
				case "ClothingShop_Close":
					ClothingShopService.ResetPreview(client);
					break;
				case "KeyboardKey_E_Pressed":
					if (client.isInVehicle) { return; }
					ClothingShopService.OpenShopMenu(client);
					break;
			}
		}

	}
}
