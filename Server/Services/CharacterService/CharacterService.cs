using System;
using System.Collections.Generic;
using System.Linq;
using SimpleRoleplay.Server.Model;
using System.Data;
using SimpleRoleplay.Server.Base;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;
using GrandTheftMultiplayer.Server.API;
using SimpleRoleplay.Server.Services.FactionService;
using GrandTheftMultiplayer.Shared.Math;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared;

namespace SimpleRoleplay.Server.Services.CharacterService
{
	class CharacterService
	{
		public static Character LoadCharacter(int id)
		{
			Character character = new Character();

			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@Id", id.ToString()}
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM characters WHERE Id = @Id LIMIT 1", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					//account.SocialClubName = (string)row["SocialClubname"];
					character.Id = id;
					character.SocialClubName = (string)row["SocialClubName"];
					character.CreatedAt = (DateTime)row["CreatedAt"];
					character.LastUsage = (DateTime)row["LastUsage"];
					character.FirstName = (string)row["FirstName"];
					character.LastName = (string)row["LastName"];
					character.Gender = (Gender)row["Gender"];
					character.Locked = (int)row["Locked"];
					character.Cash = (double)row["Cash"];
					character.Bank = (double)row["Bank"];

					character.OnDuty = Convert.ToBoolean((int)row["OnDuty"]);

					character.Faction = (FactionType)row["Faction"];
					character.FactionRank = (int)row["FactionRank"];

					character.Hunger = (int)row["Hunger"];
					character.Thirst = (int)row["Thirst"];

					character.Hair = (int)row["Hair"];
					character.HairColor = (int)row["HairColor"];
					character.HairHighlightColor = (int)row["HairHighlightColor"];
					character.Father = (int)row["Father"];
					character.Mother = (int)row["Mother"];
					character.Similarity = (float)row["Similarity"];
					character.SkinSimilarity = (float)row["SkinSimilarity"];
					character.EyebrowColor = (int)row["EyebrowColor"];
					character.BeardColor = (int)row["BeardColor"];
					character.EyeColor = (int)row["EyeColor"];
					character.BlushColor = (int)row["BlushColor"];
					character.LipstickColor = (int)row["LipstickColor"];
					character.ChestHairColor = (int)row["ChestHairColor"];
					character.Blemishes = (int)row["Blemishes"];
					character.Facialhair = (int)row["Facialhair"];
					character.Eyebrows = (int)row["Eyebrows"];
					character.Ageing = (int)row["Ageing"];
					character.Makeup = (int)row["Makeup"];
					character.Blush = (int)row["Blush"];
					character.Complexion = (int)row["Complexion"];
					character.Sundamage = (int)row["Sundamage"];
					character.Lipstick = (int)row["Lipstick"];
					character.Freckles = (int)row["Freckles"];
					character.Chesthair = (int)row["Chesthair"];

					character.ClothesTop = (int)row["ClothesTop"];
					character.ClothesLegs = (int)row["ClothesLegs"];
					character.ClothesFeets = (int)row["ClothesFeets"];

					character.Position = new Vector3((float)row["PosX"], (float)row["PosY"], (float)row["PosZ"]);

					character.Inventory = JsonConvert.DeserializeObject<List<InventoryItem>>((string)row["Inventory"]);
					character.BoughtClothing = JsonConvert.DeserializeObject<BoughtClothing>((string)row["Bought_Clothing"]);
					character.Weapons = JsonConvert.DeserializeObject<List<PlayerWeapon>>((string)row["Weapons"]);
				}
			}
			else
			{
				character = null;
			}

			return character;
		}

		public static bool ApplyAppearance(Client client, Character character = null)
		{
			if (character == null)
			{
				if (client.hasData("player"))
				{
					character = ((Player)client.getData("player")).Character;
				}
				else
				{
					return false;
				}
			}

			client.setSyncedData("CHAR_HAS_CHARACTER_DATA", true);
			client.setSyncedData("CHAR_HAIR", character.Hair);
			client.setSyncedData("CHAR_HAIR_COLOR", character.HairColor);
			client.setSyncedData("CHAR_HAIR_HIGHLIGHT_COLOR", character.HairHighlightColor);
			client.setSyncedData("CHAR_FATHER", character.Father);
			client.setSyncedData("CHAR_MOTHER", character.Mother);
			client.setSyncedData("CHAR_SIMILARITY", character.Similarity);
			client.setSyncedData("CHAR_SKIN_SIMILARITY", character.SkinSimilarity);
			client.setSyncedData("CHAR_EYEBROW_COLOR", character.EyebrowColor);
			client.setSyncedData("CHAR_BEARD_COLOR", character.BeardColor);
			client.setSyncedData("CHAR_EYE_COLOR", character.EyeColor);
			client.setSyncedData("CHAR_BLUSH_COLOR", character.BlushColor);
			client.setSyncedData("CHAR_LIPSTICK_COLOR", character.LipstickColor);
			client.setSyncedData("CHAR_CHEST_HAIR_COLOR", character.ChestHairColor);
			client.setSyncedData("CHAR_BLEMISHES", character.Blemishes);
			client.setSyncedData("CHAR_FACIAL_HAIR", character.Facialhair);
			client.setSyncedData("CHAR_EYEBROWS", character.Eyebrows);
			client.setSyncedData("CHAR_AGEING", character.Ageing);
			client.setSyncedData("CHAR_MAKEUP", character.Makeup);
			client.setSyncedData("CHAR_BLUSH", character.Blush);
			client.setSyncedData("CHAR_COMPLEXION", character.Complexion);
			client.setSyncedData("CHAR_SUNDAMAGE", character.Sundamage);
			client.setSyncedData("CHAR_LIPSTICK", character.Lipstick);
			client.setSyncedData("CHAR_FRECKLES", character.Freckles);
			client.setSyncedData("CHAR_CHEST_HAIR", character.Chesthair);

			client.setClothes((int)CharacterComponents.Hair, character.Hair, 0);

			Clothing top = ClothingService.ClothingService.TopList.FirstOrDefault(x => x.Id == character.ClothesTop);
			if (top != null)
			{
				client.setClothes((int)CharacterComponents.Top, top.Drawable, top.Texture);
				client.setClothes((int)CharacterComponents.Undershirt, top.Undershirt, 0);
				client.setClothes((int)CharacterComponents.Torso, top.Torso, 0);
			}

			Clothing legs = ClothingService.ClothingService.LegList.FirstOrDefault(x => x.Id == character.ClothesLegs);
			if(legs != null)
				client.setClothes((int)CharacterComponents.Leg, legs.Drawable, legs.Texture);
			Clothing feets = ClothingService.ClothingService.FeetList.FirstOrDefault(x => x.Id == character.ClothesFeets);
			if(feets != null)
				client.setClothes((int)CharacterComponents.Feet, feets.Drawable, feets.Texture);
			if (feets == null)
				API.shared.consoleOutput("No Feets");
			API.shared.triggerClientEventForAll("UPDATE_CHARACTER", client);
			character.Player = client;

			if(character.Faction != FactionType.Citizen && character.OnDuty)
			{
				switch (character.Faction)
				{
					case FactionType.Police:
						if (character.Gender == Gender.Male)
						{
							ClothingService.ClothingService.ApplyOutfit(client, 1); // Male Cop Outfit
						}
						else
						{
							ClothingService.ClothingService.ApplyOutfit(client, 2); // Female Cop Outfit
						}
						break;
				}
			}
			return true;
		}

		public static void CreateCharacter(Character character)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@SocialClubName", character.SocialClubName },
				{"@FirstName", character.FirstName },
				{"@LastName", character.LastName },
				{"@Gender", ((int)character.Gender).ToString() },
				{"@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
				{"@LastUsage", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
				{"@Locked", 0.ToString() },
				{"@Cash", Settings.StartMoneyCash.ToString() },
				{"@Bank", Settings.StartMoneyBank.ToString() },
				{"@Faction", ((int)character.Faction).ToString() },
				{"@FactionRank", character.FactionRank.ToString() },
				{"@Hair", character.Hair.ToString() },
				{"@HairColor", character.HairColor.ToString() },
				{"@HairHighlightColor", character.HairHighlightColor.ToString() },
				{"@Father", character.Father.ToString() },
				{"@Mother", character.Mother.ToString() },
				{"@Similarity", character.Similarity.ToString() },
				{"@SkinSimilarity", character.SkinSimilarity.ToString() },
				{"@EyebrowColor", character.EyebrowColor.ToString() },
				{"@BeardColor", character.BeardColor.ToString() },
				{"@EyeColor", character.EyeColor.ToString() },
				{"@BlushColor", character.BlushColor.ToString() },
				{"@LipstickColor", character.LipstickColor.ToString() },
				{"@ChestHairColor", character.ChestHairColor.ToString() },
				{"@Blemishes", character.Blemishes.ToString() },
				{"@Facialhair", character.Facialhair.ToString() },
				{"@Eyebrows", character.Eyebrows.ToString() },
				{"@Ageing", character.Ageing.ToString() },
				{"@Makeup", character.Makeup.ToString() },
				{"@Blush", character.Blush.ToString() },
				{"@Complexion", character.Complexion.ToString() },
				{"@Sundamage", character.Sundamage.ToString() },
				{"@Lipstick", character.Lipstick.ToString() },
				{"@Freckles", character.Freckles.ToString() },
				{"@Chesthair", character.Chesthair.ToString() },
				{"@Inventory", JsonConvert.SerializeObject(character.Inventory, Formatting.Indented) },
				{"@Bought_Clothing", JsonConvert.SerializeObject(character.BoughtClothing, Formatting.Indented) }
			};
			
			// Default Clothing
			if(character.Gender == Gender.Male)
			{
				parameters.Add("@ClothesTop", "91");
				parameters.Add("@ClothesLegs", "1");
				parameters.Add("@ClothesFeets", "1");
			}
			else
			{
				parameters.Add("@ClothesTop", "1");
				parameters.Add("@ClothesLegs", "2");
				parameters.Add("@ClothesFeets", "2");
			}

			DataTable result = DatabaseHandler.ExecutePreparedStatement("INSERT INTO characters (SocialClubName, FirstName, LastName, Gender, CreatedAt, LastUsage, Locked, " +
				"Cash, Bank, Hair, HairColor, HairHighlightColor, Father, Mother, Similarity, SkinSimilarity, EyebrowColor, BeardColor, EyeColor, BlushColor, LipstickColor, " +
				"ChestHairColor, Blemishes, Facialhair, Eyebrows, Ageing, Makeup, Blush, Complexion, Sundamage, Lipstick, Freckles, Chesthair, Faction, FactionRank, " +
				"ClothesTop, ClothesLegs, ClothesFeets, Inventory, Bought_Clothing) " +
				"VALUES (@SocialClubName, @FirstName, @LastName, @Gender, @CreatedAt, @LastUsage, @Locked, " +
				"@Cash, @Bank, @Hair, @HairColor, @HairHighlightColor, @Father, @Mother, @Similarity, @SkinSimilarity, @EyebrowColor, @BeardColor, @EyeColor, @BlushColor, @LipstickColor, " +
				"@ChestHairColor, @Blemishes, @Facialhair, @Eyebrows, @Ageing, @Makeup, @Blush, @Complexion, @Sundamage, @Lipstick, @Freckles, @Chesthair, @Faction, @FactionRank, " +
				"@ClothesTop, @ClothesLegs, @ClothesFeets, @Inventory, @Bought_Clothing)", parameters);
		}

		public static void UpdateHUD(Client client)
		{
			if (!client.hasData("player")) return;
			Player player = client.getData("player");
			if (player.Character.Hunger > 100) player.Character.Hunger = 100;
			if (player.Character.Hunger < 0) player.Character.Hunger = 0;
			if (player.Character.Thirst > 100) player.Character.Thirst = 100;
			if (player.Character.Thirst < 0) player.Character.Thirst = 0;

			client.setSyncedData("hunger", player.Character.Hunger);
			client.setSyncedData("thirst", player.Character.Thirst);
			client.setSyncedData("cash", player.Character.Cash);
		}

		public static void ShowPlayerHUD(Client client, bool status)
		{
			client.setSyncedData("hud", status);
		}

		public static void UpdatePlayerWeapons(Character character)
		{
			if(character.Player == null) { return; }
			character.Weapons.Clear();
			foreach (WeaponHash weapon in API.shared.getPlayerWeapons(character.Player))
			{
				character.Weapons.Add(new PlayerWeapon
				{
					WeaponHash = weapon,
					WeaponTint = API.shared.getPlayerWeaponTint(character.Player, weapon),
					WeaponComponents = API.shared.getPlayerWeaponComponents(character.Player, weapon),
					Ammo = API.shared.getPlayerWeaponAmmo(character.Player, weapon)
				});
			}
		}

		public static void GivePlayerWeapons(Client client)
		{
			if (!client.hasData("player")) { return; }
			Player player = client.getData("player");
			API.shared.removeAllPlayerWeapons(client);
			player.Character.Weapons.ForEach(weapon => {
				API.shared.givePlayerWeapon(client, weapon.WeaponHash, weapon.Ammo, false, true);
				API.shared.setPlayerWeaponTint(client, weapon.WeaponHash, weapon.WeaponTint);
				foreach (WeaponComponent comp in weapon.WeaponComponents)
				{
					API.shared.givePlayerWeaponComponent(client, weapon.WeaponHash, comp);
				}
			});
		}

		public static void UpdateCharacter(Character character)
		{
			UpdatePlayerWeapons(character);
			character.Position = character.Player.position;
			character.Player.setSyncedData("hunger", character.Hunger);
			character.Player.setSyncedData("thirst", character.Thirst);
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Id", character.Id.ToString() },
				{"@FirstName", character.FirstName },
				{"@LastName", character.LastName },
				{"@Gender", ((int)character.Gender).ToString() },
				{"@LastUsage", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
				{"@Locked", 0.ToString() },

				{"@Cash", character.Cash.ToString() },
				{"@Bank", character.Bank.ToString() },

				{"@OnDuty", Convert.ToInt32(character.OnDuty).ToString() },

				{"@Inventory", JsonConvert.SerializeObject(character.Inventory) },
				{"@Bought_Clothing",  JsonConvert.SerializeObject(character.BoughtClothing)},

				{"@Hair", character.Hair.ToString() },
				{"@HairColor", character.HairColor.ToString() },
				{"@HairHighlightColor", character.HairHighlightColor.ToString() },
				{"@Father", character.Father.ToString() },
				{"@Mother", character.Mother.ToString() },
				{"@Similarity", character.Similarity.ToString().Replace(",", ".") },
				{"@SkinSimilarity", character.SkinSimilarity.ToString().Replace(",", ".") },

				{"@EyebrowColor", character.EyebrowColor.ToString() },
				{"@BeardColor", character.BeardColor.ToString() },
				{"@EyeColor", character.EyeColor.ToString() },
				{"@BlushColor", character.BlushColor.ToString() },
				{"@LipstickColor", character.LipstickColor.ToString() },
				{"@ChestHairColor", character.ChestHairColor.ToString() },

				{"@Blemishes", character.Blemishes.ToString() },
				{"@Facialhair", character.Facialhair.ToString() },
				{"@Eyebrows", character.Eyebrows.ToString() },
				{"@Ageing", character.Ageing.ToString() },
				{"@Makeup", character.Makeup.ToString() },
				{"@Blush", character.Blush.ToString() },
				{"@Complexion", character.Complexion.ToString() },
				{"@Sundamage", character.Sundamage.ToString() },
				{"@Lipstick", character.Lipstick.ToString() },
				{"@Freckles", character.Freckles.ToString() },
				{"@Chesthair", character.Chesthair.ToString() },
				{"@ClothesTop", character.ClothesTop.ToString() },
				{"@ClothesLegs", character.ClothesLegs.ToString() },
				{"@ClothesFeets", character.ClothesFeets.ToString() },
				{"@PosX", character.Position.X.ToString().Replace(",", ".") },
				{"@PosY", character.Position.Y.ToString().Replace(",", ".") },
				{"@PosZ", character.Position.Z.ToString().Replace(",", ".") },
				{"@Hunger", character.Hunger.ToString() },
				{"@Thirst", character.Thirst.ToString() },

				{"@Weapons",  JsonConvert.SerializeObject(character.Weapons)}
			};

			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE characters SET FirstName = @FirstName, LastName = @LastName, Gender = @Gender, LastUsage = @LastUsage, Locked = @Locked, " +
				"Cash = @Cash, Bank = @Bank, Hair = @Hair, HairColor = @HairColor, HairHighlightColor = @HairHighlightColor, Father = @Father, Mother = @Mother, Similarity = @Similarity," +
				" SkinSimilarity = @SkinSimilarity, EyebrowColor = @EyebrowColor, BeardColor = @BeardColor, EyeColor = @EyeColor, BlushColor = @BlushColor, LipstickColor = @LipstickColor, " +
				"ChestHairColor = @ChestHairColor, Blemishes = @Blemishes, Facialhair = @Facialhair, Eyebrows = @Eyebrows, Ageing = @Ageing, Makeup = @Makeup, Blush = @Blush, " +
				"Complexion = @Complexion, Sundamage = @Sundamage, Lipstick = @Lipstick, Freckles = @Freckles, Chesthair = @Chesthair, " +
				"ClothesTop = @ClothesTop, ClothesLegs = @ClothesLegs, ClothesFeets = @ClothesFeets, PosX = @PosX, PosY = @PosY, PosZ = @PosZ, Inventory = @Inventory, " +
				"Hunger = @Hunger, Thirst = @Thirst, Bought_Clothing = @Bought_Clothing, OnDuty = @OnDuty, Weapons = @Weapons WHERE Id = @Id LIMIT 1", parameters);
		}

		public static bool HasSocialClubUserACharacter(string socialClubName)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@SocialClubName", socialClubName}
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM characters WHERE SocialClubName = @SocialClubName AND Locked = 0", parameters);

			if(result == null)
			{
				Client client = API.shared.getAllPlayers().FirstOrDefault(x => x.socialClubName.ToLower() == socialClubName.ToLower());
				if (client != null)
				{
					API.shared.kickPlayer(client, "Please Reconnect!");
				}
				API.shared.consoleOutput(LogCat.Error, $"Empty Result at (HasSocialClubUserACharacter({socialClubName}) : CharacterService.cs)");
				return false;
			}

			return result.Rows.Count != 0;
		}

		public static List<Character> LoadCharacterList(string socialClubName)
		{
			List<Character> characters = new List<Character>();
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@SocialClubName", socialClubName}
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("SELECT * FROM characters WHERE SocialClubName = @SocialClubName AND Locked = 0", parameters);
			if (result.Rows.Count != 0)
			{
				foreach (DataRow row in result.Rows)
				{
					characters.Add(LoadCharacter((int)row["Id"]));
				}
			}
			return characters;
		}

		public static void OpenCharacterSelection(Client player)
		{
			List<CharacterSelectionItem> characters = new List<CharacterSelectionItem>();
			List<Character> playercharacters = LoadCharacterList(player.socialClubName);
			playercharacters.ForEach(character => 
			{
				characters.Add(new CharacterSelectionItem(character.Id, character.FirstName + " " + character.LastName));
			});
			string jsonData = JsonConvert.SerializeObject(characters, Formatting.Indented);
			player.setData("characterselection", playercharacters);
			player.position = Settings.CharSelectCameraPedPosition;
			player.rotation = Settings.CharSelectCameraPedRotation;
			player.freeze(true);
			API.shared.triggerClientEvent(player, "open_CharacterSelection", jsonData, Settings.CharSelectCameraPosition, Settings.CharSelectCameraLookAt);
		}

		public static void OpenCharacterCreator(Client player)
		{
			API.shared.triggerClientEvent(player, "open_CharCreator");
			player.freeze(true);
		}

		public static void CloseCharacterSelection(Client player)
		{
			API.shared.triggerClientEvent(player, "close_CharacterSelection");
			player.freeze(false);
		}

		public static void UpdateLastUsage(int id)
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"@Id", id.ToString() },
				{"@LastUsage", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
			};
			DataTable result = DatabaseHandler.ExecutePreparedStatement("UPDATE characters SET LastUsage = @LastUsage WHERE Id = @Id LIMIT 1", parameters);
		}

		public static void OpenSpawnMenu(Client client)
		{
			if (!client.hasData("player"))
				return;
			Player player = client.getData("player");
			List<SpawnPosition> spawnList = new List<SpawnPosition>
			{
				new SpawnPosition("Los Santos Airport", new Vector3(-1039.654, -2739.658, 13.85765), new Vector3(0, 0, -43.09746))
			};
			if(player.Character.Position != new Vector3(0, 0, 0))
				spawnList.Add(new SpawnPosition("Last Position", player.Character.Position, new Vector3()));
			string jsonData = JsonConvert.SerializeObject(spawnList, Formatting.Indented);
			API.shared.triggerClientEvent(client, "SpawnMenu_Open", jsonData);
			client.setData("spawnlist", spawnList);
			client.position = spawnList[0].Position;
		}

		public static List<InventoryMenuItem> GetInventoryMenuItems(Client client)
		{
			List<InventoryMenuItem> inventoryMenuList = new List<InventoryMenuItem>();
			if (!client.hasData("player"))
				return null;
			Player player = client.getData("player");
			if (player.Character.Inventory.Count != 0)
			{
				player.Character.Inventory.ForEach(inventoryItem =>
				{
					Item item = ItemService.ItemService.ItemList.FirstOrDefault(x => x.Id == inventoryItem.ItemID);
					if (item != null)
					{
						inventoryMenuList.Add(new InventoryMenuItem
						{
							Id = item.Id,
							Name = item.Name,
							Description = item.Description,
							Count = inventoryItem.Count
						});
					}
				});
			}
			return inventoryMenuList;
		}

		public static Player GetNextPlayerInNearOfPlayer(Player player)
		{
			List<Player> playersaround = new List<Player>();
			API.shared.getPlayersInRadiusOfPlayer(1, player.Character.Player).ForEach(x => {
				if (x.hasData("player"))
				{
					playersaround.Add((Player)x.getData("player"));
				}
			});
			if (playersaround.Any(x => x == player))
			{
				playersaround.Remove(player);
			}
			if (playersaround.Count > 1)
			{
				return null;
			}
			if (playersaround.Count < 1)
			{
				return null;
			}
			Player target = playersaround.FirstOrDefault();
			return target;
		}
	}
}
