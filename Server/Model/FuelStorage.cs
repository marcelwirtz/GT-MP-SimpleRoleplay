namespace SimpleRoleplay.Server.Model
{
	class FuelStorage
	{
		public int Petrol { get; set; }
		public int Diesel { get; set; }
		public int Gas { get; set; }
		public int Electricity { get; set; }
		public int Kerosene { get; set; }
		public FuelStorage()
		{
			Petrol = 1000;
			Diesel = 1000;
			Gas = 0;
			Electricity = 0;
			Kerosene = 0;
		}
	}
}
