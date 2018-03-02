using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;
using SimpleRoleplay.Server.Model;
using SimpleRoleplay.Server.Services.CharacterService;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SimpleRoleplay.Server.Services.ClothingService
{
	class ClothingService
	{
		public static readonly List<Clothing> TopList = new List<Clothing>();
		public static readonly List<Clothing> LegList = new List<Clothing>();
		public static readonly List<Clothing> FeetList = new List<Clothing>();

		public static readonly List<DatabaseOutfit> OutfitList = new List<DatabaseOutfit>();

		public static void LoadAllClothing()
		{
			// Tops
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM clothes_tops", parameters);
		    if (result.Rows.Count != 0)
		    {
		        foreach (DataRow row in result.Rows)
		        {
		            TopList.Add(new Clothing
		            {
		                Id = (int) row["Id"],
		                Slot = (int) row["Slot"],
		                Drawable = (int) row["Drawable"],
		                Texture = (int) row["Texture"],
		                Torso = (int) row["Torso"],
		                StoreType = (ClothingStoreType) row["StoreType"],
		                Undershirt = (int) row["Undershirt"],
		                Gender = (Gender) row["Gender"]
		            });
		        }
		        API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Tops Loaded..");
		    }
		    else
		    {
		        API.shared.consoleOutput(LogCat.Info, "No Tops Loaded..");
		    }

			// Legs
			parameters.Clear();
			result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM clothes_legs", parameters);
		    if (result.Rows.Count != 0)
		    {
		        foreach (DataRow row in result.Rows)
		        {
		            LegList.Add(new Clothing
		            {
		                Id = (int) row["Id"],
		                Slot = (int) row["Slot"],
		                Drawable = (int) row["Drawable"],
		                Texture = (int) row["Texture"],
		                Torso = (int) row["Torso"],
		                StoreType = (ClothingStoreType) row["StoreType"],
		                Undershirt = (int) row["Undershirt"],
		                Gender = (Gender) row["Gender"]
		            });
		        }
		        API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Legs Loaded..");
		    }
		    else
		    {
		        API.shared.consoleOutput(LogCat.Info, "No Legs Loaded..");
		    }

			// Feets
			parameters.Clear();
			result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM clothes_feets", parameters);
		    if (result.Rows.Count != 0)
		    {
		        foreach (DataRow row in result.Rows)
		        {

		            FeetList.Add(new Clothing
		            {
		                Id = (int) row["Id"],
		                Slot = (int) row["Slot"],
		                Drawable = (int) row["Drawable"],
		                Texture = (int) row["Texture"],
		                Torso = (int) row["Torso"],
		                StoreType = (ClothingStoreType) row["StoreType"],
		                Undershirt = (int) row["Undershirt"],
		                Gender = (Gender) row["Gender"]
		            });
		        }
		        API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Feets Loaded..");
		    }
		    else
		    {
		        API.shared.consoleOutput(LogCat.Info, "No Feets Loaded..");
		    }

			// Outfits
			parameters.Clear();
			result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM clothes_outfits", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{

					OutfitList.Add(new DatabaseOutfit
					{
						Id = (int)row["Id"],
						Outfit = JsonConvert.DeserializeObject<Outfit>((string)row["Outfit"])
					});
				}
				API.shared.consoleOutput(LogCat.Info, result.Rows.Count + " Outfits Loaded..");
			}
			else
			{
				API.shared.consoleOutput(LogCat.Info, "No Outfits Loaded..");
			}
		}

		public static Clothing GetTopFromDb(int id)
		{
			Clothing clothing = new Clothing();
		    Dictionary<string, string> parameters = new Dictionary<string, string>
		    {
		        {"@Id", id.ToString()}
		    };
		    DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM clothes_tops WHERE Id = @Id LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					clothing.Id = (int)row["Id"];
					clothing.Slot = (int)row["Slot"];
					clothing.Drawable = (int)row["Drawable"];
					clothing.Texture = (int)row["Texture"];
					clothing.Torso = (int)row["Torso"];
					clothing.StoreType = (ClothingStoreType)row["StoreType"];
					clothing.Undershirt = (int)row["Undershirt"];
					clothing.Gender = (Gender)row["Gender"];
				}
			}
			else
			{
				return null;
			}
			return clothing;
		}

		public static void ApplyOutfit(Client client, int id)
		{
			DatabaseOutfit dboutfit = OutfitList.FirstOrDefault(x => x.Id == id);
			if(dboutfit == null) { return; }
			Outfit outfit = dboutfit.Outfit;
			client.setClothes((int)CharacterComponents.Top, outfit.Top, outfit.TopTxt);
			client.setClothes((int)CharacterComponents.Torso, outfit.Torso, 0);
			client.setClothes((int)CharacterComponents.Leg, outfit.Leg, outfit.LegTxt);
			client.setClothes((int)CharacterComponents.Feet, outfit.Feet, outfit.FeetTxt);
			client.setClothes((int)CharacterComponents.Undershirt, outfit.Undershirt, outfit.UndershirtTxt);
		}

		public static Clothing GetLegsFromDb(int id)
		{
			Clothing clothing = new Clothing();
		    Dictionary<string, string> parameters = new Dictionary<string, string>
		    {
		        {"@Id", id.ToString()}
		    };
		    DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM clothes_legs WHERE Id = @Id LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					clothing.Id = (int)row["Id"];
					clothing.Slot = (int)row["Slot"];
					clothing.Drawable = (int)row["Drawable"];
					clothing.Texture = (int)row["Texture"];
					clothing.Torso = (int)row["Torso"];
					clothing.StoreType = (ClothingStoreType)row["StoreType"];
					clothing.Undershirt = (int)row["Undershirt"];
					clothing.Gender = (Gender)row["Gender"];
				}
			}
			else
			{
				return null;
			}
			return clothing;
		}

		public static Clothing GetFeetsFromDb(int id)
		{
			Clothing clothing = new Clothing();
		    Dictionary<string, string> parameters = new Dictionary<string, string>
		    {
		        {"@Id", id.ToString()}
		    };
		    DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM clothes_feets WHERE Id = @Id LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					clothing.Id = (int)row["Id"];
					clothing.Slot = (int)row["Slot"];
					clothing.Drawable = (int)row["Drawable"];
					clothing.Texture = (int)row["Texture"];
					clothing.Torso = (int)row["Torso"];
					clothing.StoreType = (ClothingStoreType)row["StoreType"];
					clothing.Undershirt = (int)row["Undershirt"];
					clothing.Gender = (Gender)row["Gender"];
				}
			}
			else
			{
				return null;
			}
			return clothing;
		}
	}
}
