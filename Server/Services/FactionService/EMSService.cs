using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.CharacterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleRoleplay.Server.Services.FactionService
{
	class EMSService
		: Script
	{
		public EMSService()
		{
			API.onPlayerDeath += OnPlayerDeathHandler;
		}

		#region DeathEvent
		private void OnPlayerDeathHandler(Client client, NetHandle entityKiller, int weapon)
		{
			InterfaceService.ScreenService.PlayScreenEffect(client, "DeathFailOut", 10000, true);
			InterfaceService.ScreenService.SetHudVisible(client, false);
			API.sendNativeToPlayer(client, Hash._RESET_LOCALPLAYER_STATE, client);
			API.sendNativeToPlayer(client, Hash.RESET_PLAYER_ARREST_STATE, client);

			API.sendNativeToPlayer(client, Hash.IGNORE_NEXT_RESTART, true);
			API.sendNativeToPlayer(client, Hash._DISABLE_AUTOMATIC_RESPAWN, true);

			API.sendNativeToPlayer(client, Hash.SET_FADE_IN_AFTER_DEATH_ARREST, true);
			API.sendNativeToPlayer(client, Hash.SET_FADE_OUT_AFTER_DEATH, false);
			API.sendNativeToPlayer(client, Hash.NETWORK_REQUEST_CONTROL_OF_ENTITY, client);

			API.sendNativeToPlayer(client, Hash.FREEZE_ENTITY_POSITION, client, false);
			API.sendNativeToPlayer(client, Hash.NETWORK_RESURRECT_LOCAL_PLAYER, client.position.X, client.position.Y, client.position.Z, client.rotation.Z, false, false);
			API.sendNativeToPlayer(client, Hash.RESURRECT_PED, client);
			API.triggerClientEvent(client, "EMS_SetPedToRagdoll", true);
			client.invincible = true;
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			player.Character.IsDeath = true;

			if (IsMedicOnline()){
				Blip blip = API.createBlip(client);
				blip.sprite = 305;
				blip.color = 1;
				blip.name = $"Dispatch: In mortal danger! | {player.Character.FirstName} {player.Character.LastName}";
				Dispatches.Add(
					new Dispatch
					{
						Client = client,
						Player = player,
						Time = DateTime.Now,
						Blip = blip
					});
				BlipService.BlipService.BlipList.Add(blip);
				StartDeathTimer(client, 600); // Medic is Online Respawn is in 10 Minutes
			}
			else
			{
				StartDeathTimer(client, 30); // No Medic is Online Respawn in 30 Seconds
			}

		}
		#endregion DeathEvent

		#region Dispatches
		public static readonly List<Dispatch> Dispatches = new List<Dispatch>();

		#endregion Dispatches


		public static void RevivePlayer(Client client, bool hospital = false)
		{
			StopDeathTimer(client);
			if (hospital)
			{
				InterfaceService.ProgressBarService.HideBar(client);
				SpawnAtHospital(client);
				API.shared.delay(1900, true, () => {
					ResetDeathStatus(client);
				});
			}
			else
			{
				InterfaceService.ProgressBarService.HideBar(client);
				ResetDeathStatus(client);
			}
			Dispatch dispatch = Dispatches.FirstOrDefault(x => x.Client == client);
			if(dispatch != null)
			{
				if(dispatch.Blip != null)
				{
					API.shared.deleteEntity(dispatch.Blip);
				}
				Dispatches.Remove(dispatch);
			}
		}

		public static void ResetDeathStatus(Client client)
		{
			client.invincible = false;
			API.shared.triggerClientEvent(client, "EMS_SetPedToRagdoll", false);
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			player.Character.IsDeath = false;
		}

		public static bool IsMedicOnline()
		{
			bool isOnline = false;
			API.shared.getAllPlayers().ForEach(otherclient => {
				if (otherclient.hasData("player"))
				{
					Player otherplayer = otherclient.getData("player");
					if (otherplayer.Character.Faction == FactionType.EMS && otherplayer.Character.OnDuty && !otherplayer.Character.IsDeath)
					{
						isOnline = true;
					}
				}
			});
			return isOnline;
		}

		private void StartDeathTimer(Client client, int timeInSeconds)
		{
			int timercount = 0;
			InterfaceService.ProgressBarService.ShowBar(client, 0, timeInSeconds, "Respawn");
			client.setData("DeathTimer", API.startTimer(1000, false, () => {
				if(timercount >= timeInSeconds)
				{
					RevivePlayer(client, true);
				}
				timercount++;
				InterfaceService.ProgressBarService.ChangeProgress(client, timercount);
			}));
		}

		private static void StopDeathTimer(Client client)
		{
			
			if (!client.hasData("DeathTimer")) { return; }
			API.shared.stopTimer((Timer)client.getData("DeathTimer"));
			client.resetData("DeathTimer");
		}

		public static void SpawnAtHospital(Client client)
		{
			InterfaceService.ScreenService.FadeScreenOut(client, 1500);
			API.shared.delay(2000, true, () => {
				client.position = new Vector3(360.9126, -585.8543, 28.8256);
				client.rotation = new Vector3(0, 0, -114.8503);
				RevivePlayer(client);
				InterfaceService.ScreenService.FadeScreenIn(client, 2000);
				InterfaceService.ScreenService.StopAllScreenEffects(client);
				InterfaceService.ScreenService.SetHudVisible(client, true);
			});
		}


		// EMS Faction Member

		public static void SetOnDuty(Client client, bool onDuty)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");

			player.Character.OnDuty = onDuty;

			if (onDuty)
			{
				if (player.Character.Gender == Gender.Male)
				{
					ClothingService.ClothingService.ApplyOutfit(client, 5); // Male EMS Outfit
				}
				else
				{
					ClothingService.ClothingService.ApplyOutfit(client, 6); // Female EMS Outfit
				}
			}
			else
			{
				CharacterService.CharacterService.ApplyAppearance(client);
			}

			API.shared.getAllPlayers().ForEach(otherclient => {
				if (otherclient.hasData("player"))
				{
					Player otherplayer = otherclient.getData("player");
					if (otherplayer.Character.Faction == FactionType.EMS && otherplayer.Character.OnDuty)
					{
						if (onDuty)
						{
							API.shared.sendNotificationToPlayer(otherclient, $"~y~EMS Information:~n~~b~{player.Character.FirstName} {player.Character.LastName} ~w~is now ~g~on duty");
						}
						else
						{
							API.shared.sendNotificationToPlayer(otherclient, $"~y~EMS Information:~n~~b~{player.Character.FirstName} {player.Character.LastName} ~w~is now ~r~off duty");
						}
					}
				}
			});
		}

		#region EMS Interaction Menu
		public static List<MenuItem> BuildInteractionMenu(Player player)
		{
			List<MenuItem> menuItemList = new List<MenuItem>();

			// Person Options
			Player otherPlayer = CharacterService.CharacterService.GetNextPlayerInNearOfPlayer(player);
			if (otherPlayer != null)
			{

				if (otherPlayer.Character.IsDeath)
				{
					menuItemList.Add(new MenuItem
					{
						Title = "~o~Revive player",
						Value1 = "reviveplayer"
					});
				}
				else
				{
					menuItemList.Add(new MenuItem
					{
						Title = "~o~Heal player",
						Value1 = "healplayer"
					});
				}
			}
			return menuItemList;
		}


		public static void ProcessInteractionMenu(Client client, string itemvalue)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			Player otherPlayer = null;
			PlayerMenuService.CloseMenu(client);
			switch (itemvalue)
			{
				case "reviveplayer":
					otherPlayer = CharacterService.CharacterService.GetNextPlayerInNearOfPlayer(player);
					if (otherPlayer != null)
					{
						RevivePlayer(otherPlayer.Character.Player);
					}
					break;

				case "healplayer":
					otherPlayer = CharacterService.CharacterService.GetNextPlayerInNearOfPlayer(player);
					if (otherPlayer != null)
					{
						otherPlayer.Character.Player.health = 100;
					}
					break;
			}
		}
		#endregion EMS Interaction Menu
	}
}
