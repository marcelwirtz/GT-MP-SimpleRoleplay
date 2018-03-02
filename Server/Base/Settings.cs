using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared.Math;

namespace SimpleRoleplay.Server.Base
{
	public class StartUp : Script
	{
		public StartUp()
		{
			API.onResourceStart += OnResourceStartHandler;
		}

		public void OnResourceStartHandler()
		{
			LoadSettings();
		}

		public void LoadSettings()
		{
			if (API.hasSetting("server_name"))
				Settings.ServerName = API.getSetting<string>("server_name");
			if (API.hasSetting("gamemode_name"))
				Settings.GamemodeName = API.getSetting<string>("gamemode_name");
			if (API.hasSetting("whitelist_enabled"))
				Settings.WhitelistEnabled = API.getSetting<bool>("whitelist_enabled");
			API.setServerName(Settings.ServerName);
			API.setGamemodeName(Settings.GamemodeName);
		}
	}
	public class Settings
	{
		// Account

		#region Account

		public static int MinPasswordLength = 4;
		public static bool AllowNewRegistrations = true;

		#endregion Account

		#region Cameras

		public static readonly Vector3 RegisterCameraPosition = new Vector3(120.9701, -1415.109, 150.8911);
		public static readonly Vector3 RegisterCameraLookAt = new Vector3(48.17477, -1120.771, 219.4314);
		public static readonly Vector3 RegisterPedPosition = new Vector3(100.4397, -1390.407, 28.87526);
		public static readonly Vector3 LoginCameraPosition = new Vector3(120.9701, -1415.109, 150.8911);
		public static readonly Vector3 LoginCameraLookAt = new Vector3(48.17477, -1120.771, 219.4314);
		public static readonly Vector3 LoginPedPosition = new Vector3(100.4397, -1390.407, 28.87526);
		public static readonly Vector3 CharSelectCameraPosition = new Vector3(377.2062, -993.7937, -98.00002);
		public static readonly Vector3 CharSelectCameraLookAt = new Vector3(376.9842, -991.884, -98.60493);
		public static readonly Vector3 CharSelectCameraPedPosition = new Vector3(376.9842, -991.884, -98.60493);
		public static readonly Vector3 CharSelectCameraPedRotation = new Vector3(0, 0, -176.8093);

		#endregion Cameras

		#region Character
		public static double StartMoneyCash = 50;
		public static double StartMoneyBank = 2000;
		#endregion

		// General Settings
		#region General Settings
		public static string ServerName = "Simple Roleplay";
		public static string GamemodeName = "SRP Alpha";
		public static bool WhitelistEnabled = false;
		#endregion
	}
}