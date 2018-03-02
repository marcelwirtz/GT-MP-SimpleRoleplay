using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace SimpleRoleplay.Server.Model
{
	public class ATM
	{
		public int Id { get; set; }
		public Vector3 Position { get; set; }
		public double MoneyStorage { get; set; }
		public bool ShowOnMap { get; set; }
		public Blip Blip { get; set; }
		public ATM()
		{

		}
	}
}