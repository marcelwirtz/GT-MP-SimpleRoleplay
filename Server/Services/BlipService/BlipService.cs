using System;
using System.Collections.Generic;
using System.Linq;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.API;
using System.Data;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared.Math;

namespace SimpleRoleplay.Server.Services.BlipService
{
	public class BlipService 
        : Script
	{
	    public static readonly List<Blip> BlipList = new List<Blip>();

        public BlipService()
		{
			API.onResourceStop += OnResourceStopHandler;
		}

		public void OnResourceStopHandler()
		{
			BlipList.ForEach(blip =>
            {
				API.deleteEntity(blip);
			});
			BlipList.Clear();
		}

		public static void LoadCustomBlipsFromDatabase()
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM custom_blips", parameters);
		    if (result.Rows.Count != 0)
		    {
		        foreach (DataRow row in result.Rows)
		        {
		            Blip blip = API.shared.createBlip(new Vector3((float) row["PosX"], (float) row["PosY"], 0));
		            blip.color = (int) row["Color"];
		            blip.name = (string) row["Name"];
		            blip.transparency = (int) row["Transparency"];
		            blip.shortRange = Convert.ToBoolean((int) row["ShortRange"]);
		            blip.sprite = (int) row["Sprite"];
		            blip.scale = (float) row["Scale"];
		            blip.routeColor = (int) row["RouteColor"];
		            blip.flashing = Convert.ToBoolean((int) row["Flashing"]);
		            BlipList.Add(blip);
		        }
		        API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Custom Blips Loaded..");
		    }
		    else
		    {
		        API.shared.consoleOutput(LogCat.Info, "No Custom Blips Loaded..");
		    }
		}

		public static void AddCustomBlip(Blip blip)
		{
			if (BlipList.FirstOrDefault(x => x.handle == blip.handle) == null)
			{
				BlipList.Add(blip);
			}
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", blip.position.X + "" },
				{ "@PosY", blip.position.Y + "" },
				{ "@Color", blip.color + "" },
				{ "@Name", blip.name },
				{ "@Transparency", blip.transparency + "" },
				{ "@ShortRange", Convert.ToInt32(blip.shortRange) + ""},
				{ "@Sprite", blip.sprite + "" },
				{ "@RouteColor", blip.routeColor + "" },
				{ "@Flashing", Convert.ToInt32(blip.flashing) + "" }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO custom_blips (PosX, PosY, Color, Name, Transparency, ShortRange, Sprite, RouteColor, Flashing) " +
				"VALUES (@PosX, @PosY, @Color, @Name, @Transparency, @ShortRange, @Sprite, @RouteColor, @Flashing)", parameters);
		}

		public static void RemoveCustomBlip(Blip blip)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@PosX", blip.position.X + "" },
				{ "@PosY", blip.position.Y + "" },
				{ "@Color", blip.color + "" },
				{ "@Sprite", blip.sprite + "" }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("DELETE FROM custom_blips WHERE PosX = @PosX AND PosY = @PosY AND Color = @Color AND Sprite = @Sprite", parameters);
			BlipList.Remove(blip);
			API.shared.deleteEntity(blip);
		}
	}
}
