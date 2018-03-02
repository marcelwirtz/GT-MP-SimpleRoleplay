using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Services.FactionService
{
	class FactionService
	{
		public static void SetPlayerFaction(Client client, FactionType factionType, int rank = 1)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			player.Character.Faction = factionType;
			player.Character.FactionRank = rank;
			CharacterService.CharacterService.UpdateCharacter(player.Character);
		}

		public static void SetPlayerRank(Client client, int newRank)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			player.Character.FactionRank = newRank;
			CharacterService.CharacterService.UpdateCharacter(player.Character);
		}
	}
}
