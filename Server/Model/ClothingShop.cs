using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class ClothingShop
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Vector3 Position { get; set; }
		public Vector3 PedPosition { get; set; }
		public Vector3 PedRotation { get; set; }

		public List<Clothing> AvailableTops { get; set; }
		public List<Clothing> AvailableLegs { get; set; }
		public List<Clothing> AvailableFeets { get; set; }
		public List<Clothing> AvailableMasks { get; set; }
		public List<Clothing> AvailableAccessories { get; set; }

		public List<Clothing> AvailableHats { get; set; }
		public List<Clothing> AvailableGlasses { get; set; }
		public List<Clothing> AvailableEars { get; set; }
		public List<Clothing> AvailableWatches { get; set; }
		public List<Clothing> AvailableBracelets { get; set; }
		public Blip MapMarker { get; set; }
		public Ped Ped { get; set; }
		public ClothingShop()
		{
			Id = 0;
			Name = "Clothing Shop";
			Position = new Vector3();
			PedPosition = new Vector3();
			PedRotation = new Vector3();
			AvailableTops = new List<Clothing>();
			AvailableLegs = new List<Clothing>();
			AvailableFeets = new List<Clothing>();
			AvailableMasks = new List<Clothing>();
			AvailableAccessories = new List<Clothing>();
			AvailableHats = new List<Clothing>();
			AvailableGlasses = new List<Clothing>();
			AvailableEars = new List<Clothing>();
			AvailableWatches = new List<Clothing>();
			AvailableBracelets = new List<Clothing>();
		}
	}
}
