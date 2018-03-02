using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.VehicleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server
{
	class VehicleShopHandler
	: Script
	{
		public VehicleShopHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
			API.onResourceStop += OnResourceStopHandler;
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			switch (eventName)
			{
				case "KeyboardKey_E_Pressed":
					if (client.isInVehicle) { return; }
					VehicleShopService.OpenVehicleShop(client);
					break;
				case "VehicleShop_BuyVehicle":
					VehicleShopService.BuyVehicle(client, (string)arguments[0]);
					break;
			}
		}

		public void OnResourceStopHandler()
		{
			VehicleShopService.VehShopList.ForEach(vehicleShop =>
			{
				if (vehicleShop.MapMarker != null)
					API.shared.deleteEntity(vehicleShop.MapMarker);
				if (vehicleShop.Ped != null)
					API.shared.deleteEntity(vehicleShop.Ped);
			});
			VehicleShopService.VehShopList.Clear();
		}
	}
}
