using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared.Math;
using SimpleRoleplay.Server.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SimpleRoleplay.Server.Services.MoneyService
{
	public class ATMService : Script
	{
		public static readonly List<ATM> ATMList = new List<ATM>();

		public ATMService()
		{
			API.onResourceStop += OnResourceStopHandler;
		}

		public void OnResourceStopHandler()
		{
			ATMList.ForEach(delegate (ATM atm)
			{
				// Save ATM MoneyStorage?
				if (atm.Blip != null)
				{
					API.deleteEntity(atm.Blip);
				}
			});
			ATMList.Clear();
		}

		public static void LoadAllATMs()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM atms", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					ATM atm = new ATM
					{
						Id = (int) row["Id"],
						Position = new Vector3((float) row["PosX"], (float) row["PosY"], (float) row["PosZ"]),
						MoneyStorage = (double) row["MoneyStorage"],
						ShowOnMap = Convert.ToBoolean((int) row["ShowOnMap"]),
					};

					#region DEBUG

					atm.Blip = API.shared.createBlip(atm.Position);
					atm.Blip.sprite = 431;
					atm.Blip.color = 69;
					atm.Blip.scale = 0.5f;
					atm.Blip.name = "ATM";
					atm.Blip.shortRange = true;

					#endregion

					ATMList.Add(atm);
				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " ATMs Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No ATMs Loaded..");
			}
		}

		public static void AddATM(Vector3 position)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", position.X.ToString().Replace(",", ".") + "" },
				{ "@PosY", position.Y.ToString().Replace(",", ".") + "" },
				{ "@PosZ", position.Z.ToString().Replace(",", ".") + "" }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO atms (PosX, PosY, PosZ) " +
				"VALUES (@PosX, @PosY, @PosZ)", parameters);
			//API.shared.sendChatMessageToAll("Pos: " + Position.X.ToString().Replace(",", ".") + ", " + Position.Y.ToString().Replace(",", ".") + ", " + Position.Z.ToString().Replace(",", "."));
			ATM atm = new ATM
			{
				Id = 0,
				MoneyStorage = 0,
				Position = position,
				ShowOnMap = false,
			};
#region DEBUG
			atm.Blip = API.shared.createBlip(atm.Position);
			atm.Blip.sprite = 431;
			atm.Blip.color = 69;
			atm.Blip.shortRange = true;
			atm.Blip.name = "ATM";
#endregion
			ATMList.Add(atm);
		}

		public static void RemoveATM(int id)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", id + "" }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("DELETE FROM atms WHERE Id = @Id LIMIT 1", parameters);
			if (ATMList.FirstOrDefault(x => x.Id == id).Blip != null)
				API.shared.deleteEntity(ATMList.FirstOrDefault(x => x.Id == id).Blip);
			if (ATMList.FirstOrDefault(x => x.Id == id) != null)
				ATMList.Remove(ATMList.FirstOrDefault(x => x.Id == id));
		}

		public static void RemoveATM(Vector3 position)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", position.X + "" },
				{ "@PosY", position.Y + "" },
				{ "@PosZ", position.Z + "" }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("DELETE FROM atms WHERE PosX = @PosX AND PosY = @PosY AND PosZ = @PosZ LIMIT 1", parameters);
			if (ATMList.FirstOrDefault(x => x.Position == position).Blip != null)
				API.shared.deleteEntity(ATMList.FirstOrDefault(x => x.Position == position).Blip);
			if (ATMList.FirstOrDefault(x => x.Position == position) != null)
				ATMList.Remove(ATMList.FirstOrDefault(x => x.Position == position));
		}
	}
}