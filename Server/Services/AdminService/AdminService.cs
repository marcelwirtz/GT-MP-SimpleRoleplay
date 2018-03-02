using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.WorldService;
using System.Collections.Generic;
using System.Linq;

namespace SimpleRoleplay.Server.Services.AdminService
{
	class AdminService
	{
		public static readonly List<NetHandle> AdminVehicles = new List<NetHandle>();

		public static void KickPlayer(Client client, Client target, string reason)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			if (player.Account.AdminLvl >= 5)
				API.shared.kickPlayer(target, reason);
		}

		public static void LockPlayer(Client client, Client target, string reason)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			if (player.Account.AdminLvl < 8)
				return;
			API.shared.kickPlayer(target, "~r~Your account has been banned!~n~~w~Reason: ~b~" + reason);
			if (!target.hasData("player"))
				return;
			Player targetPlayer = target.getData("player");
			AccountService.AccountService.SetLockedState(targetPlayer.Account, 1);
		}

		public static void SendNotificionToAllAdmins(string message, int fromAdminLevel = 1)
		{
			API.shared.getAllPlayers().Where(x => x.hasData("player")).ToList().ForEach(client => 
			{
				Player player = client.getData("player");
				if (player.Account.AdminLvl >= fromAdminLevel)
					API.shared.sendPictureNotificationToPlayer(client, message, "CHAR_SOCIAL_CLUB", 0, 0, "~r~ADMIN NOTIFICATION", "To All Admins");
			});
		}

		public static void SpawnAdminVehicle(Client client, string veh)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			if (player.Account.AdminLvl < 5)
				return;
			Vehicle vehicle = API.shared.createVehicle(API.shared.getHashKey(veh), client.position, client.rotation, 1, 1);
			vehicle.numberPlate = "ADMIN";
			vehicle.setData("admin", true);
			API.shared.setPlayerIntoVehicle(client, vehicle, -1);
			AdminVehicles.Add(vehicle);
			SendNotificionToAllAdmins("[SRP]" + client.socialClubName + " Spawned a Vehicle(" + veh + ")", 5);
		}

		public static void ForceWeather(Client client, int weatherId)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			if (player.Account.AdminLvl < 5)
				return;
			WeatherService.ChangeWeatherOnce(weatherId);
			SendNotificionToAllAdmins(client.socialClubName + " changed Weather to ID: " + weatherId, 5);
		}
	}
}
