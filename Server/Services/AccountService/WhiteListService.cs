using System.Collections.Generic;
using System.Data;

namespace SimpleRoleplay.Server.Services.AccountService
{
	internal class WhiteListService
	{
		public static bool IsClientWhitelisted(string SocialClubName)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@SocialClubName", SocialClubName}
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM whitelist WHERE SocialClubName = @SocialClubName LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void AddClientToWhitelist(string SocialClubName)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@SocialClubName", SocialClubName }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO whitelist (SocialClubName) VALUES (@SocialClubName)", parameters);
		}

		public static void RemoveClientFromWhitelist(string SocialClubName)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@SocialClubName", SocialClubName }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("DELETE FROM whitelist WHERE SocialClubName = @SocialClubName LIMIT 1", parameters);
		}
	}
}