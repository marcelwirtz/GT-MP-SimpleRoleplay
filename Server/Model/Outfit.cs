using SimpleRoleplay.Server.Services.CharacterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class Outfit
	{
		public string Name { get; set; }
		public Gender Gender { get; set; }
		public int Torso { get; set; }
		public int TorsoTxt { get; set; }
		public int Top { get; set; }
		public int TopTxt { get; set; }
		public int Leg { get; set; }
		public int LegTxt { get; set; }
		public int Feet { get; set; }
		public int FeetTxt { get; set; }
		public int Undershirt { get; set; }
		public int UndershirtTxt { get; set; }
		public int Hat { get; set; }
		public int HatTxt { get; set; }

		public Outfit()
		{
			Name = "";
			Gender = Gender.Male;
			Torso = 0;
			TorsoTxt = 0;
			Top = 0;
			TopTxt = 0;
			Leg = 0;
			LegTxt = 0;
			Feet = 0;
			FeetTxt = 0;
			Undershirt = 0;
			UndershirtTxt = 0;
			Hat = -1;
			HatTxt = 0;
		}
	}

	class DatabaseOutfit
	{
		public int Id { get; set; }
		public Outfit Outfit { get; set; }
		public DatabaseOutfit()
		{
			Id = 0;
			Outfit = new Outfit();
		}
	}
}
