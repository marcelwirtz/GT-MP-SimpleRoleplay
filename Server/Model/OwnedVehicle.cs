using GrandTheftMultiplayer.Server.Elements;
using SimpleRoleplay.Server.Services.FactionService;
using System.Collections.Generic;

namespace SimpleRoleplay.Server.Model
{
	public class OwnedVehicle
	{
		public int Id { get; set; }
		public string Owner { get; set; }
		public int OwnerCharId { get; set; }
		public int Model { get; set; }
		public string ModelName { get; set; }
		public int EngineHealth { get; set; }
		public int Fuel { get; set; }
		public FactionType Faction { get; set; }
		public bool InUse { get; set; }

		public string NumberPlate { get; set; }
		public int PrimaryColor { get; set; }
		public int SecondaryColor { get; set; }
		public int Livery { get; set; }

		public List<InventoryItem> Inventory { get; set; }

		public Vehicle ActiveHandle { get; set; }
		public OwnedVehicle()
		{
			Inventory = new List<InventoryItem>();
			Livery = 0;
		}
	}
}
