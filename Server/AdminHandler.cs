using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using SimpleRoleplay.Server.Services.AdminService;

namespace SimpleRoleplay.Server
{
	class AdminHandler 
		: Script
	{
		public AdminHandler()
		{
			API.onResourceStop += OnResourceStopHandler;
			API.onPlayerExitVehicle += OnPlayerExitVehicleHandler;
		}

		public void OnResourceStopHandler()
		{
			AdminService.AdminVehicles.ForEach(veh => 
			{
				API.deleteEntity(veh);
			});
			AdminService.AdminVehicles.Clear();
		}

		private void OnPlayerExitVehicleHandler(Client player, NetHandle vehicle, int fromSeat)
		{
			if (API.hasEntityData(vehicle, "admin") && fromSeat == -1)
			{
				AdminService.AdminVehicles.Remove(vehicle);
				API.deleteEntity(vehicle);
			}
		}
	}
}
