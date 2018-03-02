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
	class GasStationHandler
	: Script
	{
		public GasStationHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
			API.onPlayerDisconnected += OnPlayerDisconnectedHandler;
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
					if (client.hasData("refuelTimer")) { GasStationService.StopRefill(client); return; }
					GasStationService.OpenGasStationMenu(client);
					break;
				case "GasStation_Begin":
					FuelType fuelType = (FuelType)((int)arguments[0]);
					OwnedVehicle ownedVehicle = VehicleService.OwnedVehicleList.FirstOrDefault(x => x.Id == (int)arguments[1]);
					if(ownedVehicle == null) { return; }
					GasStationService.StartRefill(client, ownedVehicle, fuelType);
					GasStationService.CloseMenu(client);
					break;
			}
		}

		private void OnPlayerDisconnectedHandler(Client client, string reason)
		{
			// Stop Refuel Timer if active for client
			if (client.hasData("refuelTimer")) { GasStationService.StopRefill(client); }
		}

		public void OnResourceStopHandler()
		{
			// Stop Refuel Timer if active for all clients
			API.getAllPlayers().ForEach(client => {
				if (client.hasData("refuelTimer")) { GasStationService.StopRefill(client); }
			});
		}
	}
}
