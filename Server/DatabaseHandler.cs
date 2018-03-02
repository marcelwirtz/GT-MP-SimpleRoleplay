using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using System.Data;
using SimpleRoleplay.Server.Services.MoneyService;
using SimpleRoleplay.Server.Services.BlipService;
using SimpleRoleplay.Server.Services.ClothingService;
using SimpleRoleplay.Server.Services.ItemService;
using SimpleRoleplay.Server.Services.ShopService;
using SimpleRoleplay.Server.Services.VehicleService;
using SimpleRoleplay.Server.Services.DoorService;
/*
MIT License

Copyright (c) 2018 MrNeta (https://github.com/MrNeta/GT-MP-SimpleRoleplay/)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE
*/
namespace SimpleRoleplay.Server
{
	 
	class DatabaseHandler 
		: Script
	{
		private static MySqlConnection _connection;
		private string _server;
		private string _database;
		private string _uid;
		private string _password;

		// Server Start Password
		private string oldServerPassword;

		//Constructor
		public DatabaseHandler()
		{
			API.onResourceStop += OnResourceStopHandler;
			API.onResourceStart += OnResourceStartHandler;
		}

		public void OnResourceStartHandler()
		{
			oldServerPassword = API.getServerPassword();
			Random rand = new Random();
			API.shared.setServerPassword(rand.Next().ToString());
			API.consoleOutput("Locked Server with Password: " + API.getServerPassword());
			Initialize();
		}

		public void OnResourceStopHandler()
		{
			if (CloseConnection())
			{
				API.consoleOutput(LogCat.Info, "Closed Database connection..");
			}
			else
			{
				API.consoleOutput(LogCat.Error, "Could not close Database connection..");
			}
		}

		//Initialize values
		private void Initialize()
		{
			if (API.hasSetting("mysql_server")) _server = API.getSetting<string>("mysql_server");
			if (API.hasSetting("mysql_user")) _uid = API.getSetting<string>("mysql_user");
			if (API.hasSetting("mysql_password")) _password = API.getSetting<string>("mysql_password");
			if (API.hasSetting("mysql_database")) _database = API.getSetting<string>("mysql_database");
			if (_server == null || _database == null || _uid == null || _password == null)
			{
				API.consoleOutput(LogCat.Fatal, "Some MySQL Informations are missing!");
			}
			else
			{
				var connectionString = "SERVER=" + _server + ";" + "DATABASE=" + _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + "; convert zero datetime=True";

				_connection = new MySqlConnection(connectionString);

				if (OpenConnection())
				{
					if(_connection.State != ConnectionState.Open) { API.consoleOutput(LogCat.Fatal, "Connection State: " + _connection.State); Initialize(); return; }
					API.consoleOutput(LogCat.Info, "Successful connected with the Database.");
					//CloseConnection();
					Dictionary<string, string> parameters = new Dictionary<string, string>();
					#region Startup Data Count Info
					DataTable result = ExecutePreparedStatement("SELECT COUNT(*) AS accountcount FROM accounts", parameters);
					if (result.Rows.Count != 0)
					{
						// Datenbank Eintrag gefunden
						foreach (DataRow row in result.Rows)
						{
							API.consoleOutput(LogCat.Info, "Found " + row["accountcount"] + " Accounts.");
						}
					}
					#endregion
					if (CheckDatabaseStructure())
					{
						LoadAllMySQLInformations();
					}
				}
				else
				{
					API.consoleOutput(LogCat.Fatal, "Could not connect to Database!");
				}
			}

		}

		//open connection to database
		private bool OpenConnection()
		{
			try
			{
				_connection.Open();
				return true;
			}
			catch (MySqlException ex)
			{
				//When handling errors, you can your application's response based 
				//on the error number.
				switch (ex.Number)
				{
					case 0:
						API.consoleOutput(LogCat.Error, "Cannot connect to server..");
						API.consoleOutput(LogCat.Error, ex.Message);
						break;
					case 1044:
						API.consoleOutput(LogCat.Error, $"Access denied for user '{_uid}'@'{_password}' to database '{_database}' (ErrCode: {ex.Number})");
						break;
					case 1045:
						API.consoleOutput(LogCat.Error, $"Invalid username/password.. (ErrCode: {ex.Number})");
						break;
					case 1051:
						API.consoleOutput(LogCat.Error, " Unknown table '" + _database + $"' (ErrCode: {ex.Number})");
						break;
				}
				return false;
			}
		}


		//Close connection
		private bool CloseConnection()
		{
			try
			{
				_connection.Close();
				return true;
			}
			catch (MySqlException ex)
			{
				API.consoleOutput(LogCat.Error, ex.Message);
				return false;
			}
		}

		public static DataTable ExecutePreparedStatement(string sql, Dictionary<string, string> parameters)
		{
			using (MySqlConnection conn = _connection)
			{
				try
				{
					MySqlCommand cmd = new MySqlCommand(sql, conn);
					if (conn.State != ConnectionState.Open && conn.State != ConnectionState.Connecting)
					{
						conn.Open();
					}					

					foreach (KeyValuePair<string, string> entry in parameters)
					{
						cmd.Parameters.AddWithValue(entry.Key, entry.Value);
					}

					MySqlDataReader rdr = cmd.ExecuteReader();
					DataTable results = new DataTable();
					results.Load(rdr);
					rdr.Close();
					return results;
				}
				catch (Exception ex)
				{
					API.shared.consoleOutput(LogCat.Error, "DATABASE: [ERROR] " + ex.ToString());
					return null;
				}
			}
		}
		/*
			DataTable result = Database.executeQueryWithResult(query);
			if (result.Rows.Count != 0)
			{
				// Datenbank Eintrag gefunden
				foreach (DataRow row in result.Rows)
				{
					row[""];
				}
			}
		*/

		private bool CheckDatabaseStructure()
		{
			bool returnvar = false;
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@database", _database }
			};
			DataTable result = ExecutePreparedStatement("SELECT COUNT(*) AS count FROM information_schema.tables WHERE table_schema = @database AND " +
				"(table_name = 'accounts' OR " +		// 1
				"table_name = 'atms' OR " +             // 2
				"table_name = 'characters' OR " +       // 3
				"table_name = 'clothes_feets' OR " +    // 4
				"table_name = 'clothes_legs' OR " +     // 5
				"table_name = 'clothes_tops' OR " +     // 6
				"table_name = 'clothingshops' OR " +    // 7
				"table_name = 'custom_blips' OR " +     // 8
				"table_name = 'doors' OR " +            // 9
				"table_name = 'garages' OR " +          // 10
				"table_name = 'gasstations' OR " +      // 11
				"table_name = 'items' OR " +            // 12
				"table_name = 'ownedvehicles' OR " +    // 13
				"table_name = 'shops' OR " +            // 14
				"table_name = 'vehicleinfo' OR " +      // 15
				"table_name = 'vehicleshops' OR " +     // 16
				"table_name = 'whitelist')"             // 17
				, parameters);
			if (result.Rows.Count != 0)
			{ 
				foreach (DataRow row in result.Rows)
				{
					if(Convert.ToInt32(row["count"]) >= 17)
					{
						API.consoleOutput(LogCat.Info, "Database structure is okay..");
						returnvar = true;
					}
					else
					{
						API.consoleOutput(LogCat.Fatal, "Some Database Tables are missing! (Check your Database Tables)");
						API.consoleOutput(LogCat.Warn, "Start process was stopped..");
						returnvar = false;
					}
				}
			}
			else
			{
				returnvar = false;
			}
			return returnvar;
		}

		public void LoadAllMySQLInformations()
		{
			ATMService.LoadAllATMs();
			BlipService.LoadCustomBlipsFromDatabase();
			ClothingService.LoadAllClothing();
			ItemService.LoadItemsFromDB();
			ShopService.LoadShopsFromDB();
			GarageService.LoadAllGarageFromDB();
			VehicleService.ResetAllVehicles();
			GasStationService.LoadAllGasStationsFromDB();
			VehicleService.LoadVehicleInformationsFromDB();
			VehicleShopService.LoadAllVehicleShopsFromDB();
			DoorService.LoadAllDoorsFromDB();
			ClothingShopService.LoadAllClothingShopsFromDB();

			API.delay(3000, true, () =>
			{
				API.setServerPassword(oldServerPassword);
				API.consoleOutput("Server is now unlocked..");
			});
		}
	}
}
