using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace SimpleRoleplay.Server.Services.InterfaceService
{
	internal class ProgressBarService
	{
		public static void ShowBar(Client client, int startUnit, int maxUnit, string label = "")
		{
			if (!IsBarVisible(client))
			{
				client.setSyncedData("progressbar_progress", startUnit);
				API.shared.triggerClientEvent(client, "ShowProgressbar", startUnit, maxUnit, label);
			}
		}

		public static void ChangeProgress(Client client, int currentUnit)
		{
			if (IsBarVisible(client))
			{
				client.setSyncedData("progressbar_progress", currentUnit);
			}
		}

		public static void HideBar(Client client)
		{
			if (IsBarVisible(client))
			{
				client.resetSyncedData("progressbar_progress");
				API.shared.triggerClientEvent(client, "HideProgressbar");
			}
		}

		public static int GetCurrentUnit(Client client)
		{
			if (IsBarVisible(client))
			{
				return (int)client.getSyncedData("progressbar_progress");
			}
			return -1;
		}

		public static bool IsBarVisible(Client client)
		{
			return client.hasSyncedData("progressbar_progress");
		}
	}
}