using SimpleRoleplay.Server.Services.ItemService;

namespace SimpleRoleplay.Server.Model
{
	class Item
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ItemType Type { get; set; }
		public int Weight { get; set; }
		public double DefaultPrice { get; set; }
		public double DefaultSellPrice { get; set; }
		public int Value1 { get; set; }
		public int Value2 { get; set; }
		public bool Sellable { get; set; }
	}
}
