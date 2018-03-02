using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.CharacterService;
using SimpleRoleplay.Server.Services.FactionService;
using System.Collections.Generic;

namespace SimpleRoleplay.Server
{
	class SpawnHandler 
		: Script
	{
		public SpawnHandler()
		{
			API.onClientEventTrigger += OnClientEvent;
		}

		public void OnClientEvent(Client client, string eventName, params object[] arguments)
		{
			List<SpawnPosition> spawnList;
			switch (eventName)
			{
				case "SpawnMove":
					if (!client.hasData("spawnlist"))
						return;
					spawnList = client.getData("spawnlist");
					API.moveEntityPosition(client, spawnList[(int)arguments[0]].Position, 1000);
					API.triggerClientEvent(client, "SpawnMovePed");
					client.rotation = new Vector3(0, 0, 0);
					break;
				case "SpawnSelected":
					if (!client.hasData("spawnlist"))
						return;
					spawnList = client.getData("spawnlist");
					API.triggerClientEvent(client, "SpawnMenu_Close");
					client.rotation = spawnList[(int)arguments[0]].Rotation;
					spawnList.Clear();
					client.resetData("spawnlist");
					CharacterService.ShowPlayerHUD(client, true);
					client.dimension = 0;
					if (!client.hasData("player")) { return; }
					Player player = client.getData("player");
					if (player.Character.OnDuty)
					{
						if (player.Character.Faction != FactionType.Citizen)
						{
							switch (player.Character.Faction)
							{
								case FactionType.Police:
									PoliceService.SetOnDuty(client, true);
									break;
								case FactionType.EMS:
									EMSService.SetOnDuty(client, true);
									break;
							}
						}else { player.Character.OnDuty = false;}
					}
					CharacterService.GivePlayerWeapons(client);
					break;
			}
		}

	}
}
