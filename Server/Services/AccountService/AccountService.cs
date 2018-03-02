using System;
using System.Collections.Generic;
using System.Data;
using SimpleRoleplay.Server.Model;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.API;

namespace SimpleRoleplay.Server.Services.AccountService
{
	class AccountService
	{
		public static Account LoadAccount(string socialClub)
		{
			Account account = new Account();
		    Dictionary<string, string> parameters = new Dictionary<string, string>
		    {
		        {"@SocialClubName", socialClub}
		    };
		    DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM accounts WHERE SocialClubName = @SocialClubName LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					account.SocialClubName = (string)row["SocialClubname"];
					account.Password = (string)row["Password"];
					account.CreatedAt = (DateTime)row["CreatedAt"];
					account.LastUsage = (DateTime)row["LastUsage"];
					account.LastIP = (string)row["LastIP"];
					account.LastHWID = (string)row["LastHWID"];
					account.Locked = (int)row["Locked"];
					account.MaxCharacters = (int)row["MaxCharacters"];
					account.AdminLvl = (int)row["AdminLvl"];
				}
			}
			else
			{
				account = null;
			}
			return account;
		}

		public static Account CreateAccount(Client client, string plainPassword)
		{
		    Account account = new Account
		    {
		        Password = API.shared.getPasswordHashBCrypt(plainPassword),
		        LastHWID = client.uniqueHardwareId,
		        LastIP = client.address,
		        LastUsage = DateTime.Now,
		        CreatedAt = DateTime.Now,
		        Locked = 0,
		        MaxCharacters = 1,
		        SocialClubName = client.socialClubName
		    };
		    Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@SocialClubName", account.SocialClubName },
				{ "@LastIP", account.LastIP },
				{ "@LastHWID", account.LastHWID },
				{ "@Password", account.Password },
				{ "@LastUsage", account.LastUsage.ToString("yyyy-MM-dd HH:mm:ss") },
				{ "@CreatedAt", account.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") },
				{ "@Locked", account.Locked.ToString() },
				{ "@MaxCharacters", account.MaxCharacters.ToString() }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO accounts (SocialClubName, LastIP, LastHWID, Password, LastUsage, CreatedAt, Locked, MaxCharacters) " +
				"VALUES (@SocialClubName, @LastIP, @LastHWID, @Password, @LastUsage, @CreatedAt, @Locked, @MaxCharacters)", parameters);
			account.Player = client;
			Player player = new Player
			{
				Account = account
			};
			client.setData("player", player);
			return account;
		}

		public static bool CheckPassword(string plainPassword, Account account)
		{
			return API.shared.verifyPasswordHashBCrypt(plainPassword, account.Password);
		}

		public static void LoginPlayer(Account account, Client client)
		{
			account.LastUsage = DateTime.Now;
			account.LastIP = client.address;
			account.LastHWID = client.uniqueHardwareId;

			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@SocialClubName", client.socialClubName },
				{ "@LastUsage", account.LastUsage.ToString("yyyy-MM-dd HH:mm:ss") },
				{ "@LastIP", account.LastIP },
				{ "@LastHWID", account.LastHWID },
				{ "@LoggedIn", "1" }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE accounts SET LastUsage = @LastUsage, LastIP = @LastIP, LastHWID = @LastHWID, LoggedIn = @LoggedIn" +
				" WHERE SocialClubName = @SocialClubName LIMIT 1", parameters);
			Player player = new Player
			{
				Account = account
			};
			account.Player = client;
			client.setData("player", player);
		}

		public static void SaveAndLogoutPlayer(Account account)
		{
			account.LastUsage = DateTime.Now;
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@SocialClubName", account.Player.socialClubName },
				{ "@LastUsage", account.LastUsage.ToString("yyyy-MM-dd HH:mm:ss") },
				{ "@LoggedIn", "0" }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE accounts SET LastUsage = @LastUsage, LoggedIn = @LoggedIn" +
				" WHERE SocialClubName = @SocialClubName LIMIT 1", parameters);
			account.Player.resetData("player");
		}

		public static void SetLockedState(Account account, int state)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@SocialClubName", account.Player.socialClubName },
				{ "@Locked", state.ToString() }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE accounts SET Locked = @Locked" +
				" WHERE SocialClubName = @SocialClubName LIMIT 1", parameters);
		}
	}
}
