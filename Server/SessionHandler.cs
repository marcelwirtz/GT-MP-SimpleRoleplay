using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Base;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.AccountService;
using SimpleRoleplay.Server.Services.CharacterService;

namespace SimpleRoleplay.Server
{
	class SessionHandler 
        : Script
	{
		public SessionHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
			API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;
		}

		#region OnPlayerFinishedDownloadHandler

		private void OnPlayerFinishedDownloadHandler(Client player)
		{
			if (player.hasData("preaccount"))
			{
				Account account = player.getData("preaccount");
				API.triggerClientEvent(player, "setLoginUiVisible", true, Settings.LoginCameraPosition, Settings.LoginCameraLookAt);
				player.position = Settings.LoginPedPosition;
			}
			else
			{
				if (Settings.AllowNewRegistrations)
				{
					API.triggerClientEvent(player, "setRegisterUiVisible", true, Settings.RegisterCameraPosition, Settings.RegisterCameraLookAt, Settings.MinPasswordLength);
					player.position = Settings.RegisterPedPosition;
				}
				else
				{
					API.kickPlayer(player, "Sorry, New registrations are disabled..");
				}
			}
		}

		#endregion OnPlayerFinishedDownloadHandler

		#region OnClientEvent

		public void OnClientEvent(Client client, string eventName, params object[] arguments)
		{
			switch (eventName)
			{
				case "account_loginButtonPressed":
					if (client.hasData("preaccount"))
					{
						Account account = client.getData("preaccount");
						if (AccountService.CheckPassword((string)arguments[0], account))
						{
							AccountService.LoginPlayer(account, client);
							API.sendNotificationToPlayer(client, "~g~Login Success");
							API.triggerClientEvent(client, "setLoginUiVisible", false);
							client.resetData("preaccount");
							API.delay(1000, true, () => 
                            {
								if (CharacterService.HasSocialClubUserACharacter(client.socialClubName))
								{
									CharacterService.OpenCharacterSelection(client);
								}
								else
								{
									CharacterService.OpenCharacterCreator(client);
								}
							});
						}
						else
						{
							API.sendNotificationToPlayer(client, "~r~Wrong Password!");
						}
					}
					break;

				case "account_registerButtonPressed":
					if ((string)arguments[0] == (string)arguments[1])
					{
						string passwd = (string)arguments[0];
						if (passwd.Length >= Settings.MinPasswordLength)
						{
							API.triggerClientEvent(client, "setRegisterUiVisible", false);
							Account account = AccountService.CreateAccount(client, passwd);
							if (account != null)
							{
								CharacterService.OpenCharacterCreator(client);
								API.sendChatMessageToPlayer(client, "~g~Account created!");
							}
						}
					}
					break;
			}
		}

		#endregion OnClientEvent
	}
}