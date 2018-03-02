using SimpleRoleplay.Server.Services.VehicleService;

namespace SimpleRoleplay.Server.Model
{
	public class VehicleInfo
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public string DisplayName { get; set; }
		public int MaxFuel { get; set; }
		public FuelType Fuel { get; set; }
		public int MaxStorage { get; set; }
		public VehicleType Type { get; set; }

		public VehicleInfo()
		{
			Id = 0;
			Model = "";
			DisplayName = "";
			MaxFuel = 100;
			Fuel = FuelType.Petrol;
			MaxStorage = 0;
			Type = VehicleType.Car;
		}
	}
}