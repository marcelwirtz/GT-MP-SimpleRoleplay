using GrandTheftMultiplayer.Server.Elements;
using System;
using System.Collections.Generic;
using SimpleRoleplay.Server.Services.CharacterService;
using SimpleRoleplay.Server.Services.FactionService;
using GrandTheftMultiplayer.Shared.Math;

namespace SimpleRoleplay.Server.Model
{
	class Character
	{
		// Account
		public string SocialClubName { get; set; }
		public Client Player { get; set; }

		// General Information
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Gender Gender { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUsage { get; set; }
		public int Locked { get; set; }
		public int Hunger { get; set; }
		public int Thirst { get; set; }

		public bool IsCuffed { get; set; }
		public bool IsDeath { get; set; }

		// Faction
		public bool OnDuty { get; set; }
		public bool HasHandsup { get; set; }

		// Inventory
		public List<InventoryItem> Inventory { get; set; }

		// Postion
		public Vector3 Position { get; set; }
		public Vector3 Rotation { get; set; }

		// Money
		public double Cash { get; set; }
		public double Bank { get; set; }

		// Faction
		public FactionType Faction { get; set; }
		public int FactionRank { get; set; }

		// Clothing
		public int ClothesTop { get; set; }
		public int ClothesLegs { get; set; }
		public int ClothesFeets { get; set; }

		public BoughtClothing BoughtClothing { get; set; }

		// Cosmetic
		public int Hair { get; set; }
		public int HairColor { get; set; }
		public int HairHighlightColor { get; set; }
		public int Father { get; set; }
		public int Mother { get; set; }
		public float Similarity { get; set; }
		public float SkinSimilarity { get; set; }

		public int EyebrowColor { get; set; }
		public int BeardColor { get; set; }
		public int EyeColor { get; set; }
		public int BlushColor { get; set; }
		public int LipstickColor { get; set; }
		public int ChestHairColor { get; set; }

		public int Blemishes { get; set; }
		public int Facialhair { get; set; }
		public int Eyebrows { get; set; }
		public int Ageing { get; set; }
		public int Makeup { get; set; }
		public int Blush { get; set; }
		public int Complexion { get; set; }
		public int Sundamage { get; set; }
		public int Lipstick { get; set; }
		public int Freckles { get; set; }
		public int Chesthair { get; set; }

		public List<PlayerWeapon> Weapons { get; set; }

		public Character()
		{
			Id = 0;
			SocialClubName = "";
			FirstName = "";
			LastName = "";
			Gender = Gender.Male;
			Locked = 0;
			Cash = 0;
			Bank = 0;

			IsDeath = false;
			IsCuffed = false;
			HasHandsup = false;

			Hunger = 100;
			Thirst = 100;

			Inventory = new List<InventoryItem>();

			Position = new Vector3();
			Rotation = new Vector3();

			BoughtClothing = new BoughtClothing();

			Faction = FactionType.Citizen;
			FactionRank = 0;

			ClothesTop = 0;
			ClothesLegs = 0;
			ClothesFeets = 0;

			Hair = 0;
			HairColor = 0;
			HairHighlightColor = 0;
			Father = 0;
			Mother = 0;
			Similarity = 0;
			SkinSimilarity = 0;
			EyebrowColor = 0;
			BeardColor = 0;
			EyeColor = 0;
			BlushColor = 0;
			LipstickColor = 0;
			ChestHairColor = 0;
			Blemishes = 0;
			Facialhair = 0;
			Eyebrows = 0;
			Ageing = 0;
			Makeup = 0;
			Blush = 0;
			Complexion = 0;
			Sundamage = 0;
			Lipstick = 0;
			Freckles = 0;
			Chesthair = 0;

			Weapons = new List<PlayerWeapon>();
		}
	}
}
