using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Base;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.AccountService;
using SimpleRoleplay.Server.Services.CharacterService;

namespace SimpleRoleplay.Server
{
	internal class ConnectionHandler 
		: Script
	{
		public ConnectionHandler()
		{
			API.onPlayerConnected += OnPlayerConnectedHandler;
			API.onPlayerDisconnected += OnPlayerDisconnectedHandler;
		}

		#region OnPlayerConnectedHandler

		private void OnPlayerConnectedHandler(Client client)
		{
			if (Settings.WhitelistEnabled)
			{
				if (!WhiteListService.IsClientWhitelisted(client.socialClubName))
				{
					API.kickPlayer(client, "You are not whitelisted on this server");
					return;
				}
			}
			Account account = AccountService.LoadAccount(client.socialClubName);
			if (account != null)
			{
				// User has an account
				if(account.Locked == 1)
				{
					API.kickPlayer(client, "Your Account is Locked!");
					return;
				}
				client.setData("preaccount", account);
			}
			client.dimension = -10 - API.getAllPlayers().Count;
		}

		#endregion OnPlayerConnectedHandler

		#region OnPlayerDisconnectedHandler

		private void OnPlayerDisconnectedHandler(Client client, string reason)
		{
			if (client.hasData("player"))
			{
				Player player = (Player)client.getData("player");
				CharacterService.UpdateCharacter(player.Character);
				AccountService.SaveAndLogoutPlayer(player.Account);
			}
		}

		#endregion OnPlayerDisconnectedHandler
	}
}