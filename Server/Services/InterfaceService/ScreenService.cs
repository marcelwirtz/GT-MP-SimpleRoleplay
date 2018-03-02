using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Services.InterfaceService
{
	class ScreenService
	{
		public static void FadeScreenIn(Client client, int time = 1000)
		{
			API.shared.triggerClientEvent(client, "fadeScreenIn", time);
		}

		public static void FadeScreenOut(Client client, int time = 1000)
		{
			API.shared.triggerClientEvent(client, "fadeScreenOut", time);
		}

		public static void ShowShard(Client client, string message, int time = 2000)
		{
			API.shared.triggerClientEvent(client, "showShard", message, time);
		}

		public static void ShowMissionPassedMessage(Client client, string message, int time = 2000)
		{
			API.shared.triggerClientEvent(client, "showMissionPassedMessage", message, time);
		}

		public static void ShowRankupMessage(Client client, string message, string subtitle, int rank, int time = 2000)
		{
			API.shared.triggerClientEvent(client, "showRankupMessage", message, subtitle, rank, time);
		}

		public static void ShowOldMessage(Client client, string message, int time = 2000)
		{
			API.shared.triggerClientEvent(client, "showOldMessage", message, time);
		}

		public static void ShowColoredShard(Client client, string message, string description, int textColor, int bgColor, int time = 2000)
		{
			API.shared.triggerClientEvent(client, "showColoredShard", message, description, textColor, bgColor, time);
		}

		public static void PlayScreenEffect(Client client, string effectName, int duration, bool looped = false)
		{
			API.shared.triggerClientEvent(client, "playScreenEffect", effectName, duration, looped);
		}

		public static void StopScreenEffect(Client client, string effectName)
		{
			API.shared.triggerClientEvent(client, "stopScreenEffect", effectName);
		}

		public static void StopAllScreenEffects(Client client)
		{
			API.shared.triggerClientEvent(client, "stopAllScreenEffects");
		}

		public static void SetHudVisible(Client client, bool visible)
		{
			API.shared.triggerClientEvent(client, "setHudVisible", visible);
			CharacterService.CharacterService.ShowPlayerHUD(client, visible);
		}
	}
}
