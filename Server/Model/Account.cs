using System;
using GrandTheftMultiplayer.Server.Elements;

namespace SimpleRoleplay.Server.Model
{
	public class Account
	{
		public Client Player { get; set; }
		public string SocialClubName { get; set; }
		public string Password { get; set; }
		public int AdminLvl { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUsage { get; set; }
		public string LastIP { get; set; }
		public string LastHWID { get; set; }
		public int Locked { get; set; }
		public int MaxCharacters { get; set; }

		public Account()
		{

		}
	}
}
