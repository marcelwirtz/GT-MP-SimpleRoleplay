using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using System.Collections.Generic;

namespace SimpleRoleplay.Server.Model
{
	class GasStation
	{
		public int Id { get; set; }
		public Vector3 Position { get; set; }
		public List<Vector3> GasPumps { get; set; }
		public FuelPrices StationFuelPrices { get; set; }
		public FuelStorage Storage { get; set; }
		public double MoneyStorage { get; set; }
		public Blip MapMarker { get; set; }
		public GasStation()
		{
			Id = 0;
			Position = new Vector3();
			GasPumps = new List<Vector3>();
			StationFuelPrices = new FuelPrices();
			Storage = new FuelStorage();
			MoneyStorage = 0;
		}
	}
}
