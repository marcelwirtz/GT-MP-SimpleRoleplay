namespace SimpleRoleplay.Server.Model
{
	class FuelPrices
	{
		public double Petrol { get; set; }
		public double Diesel { get; set; }
		public double Gas { get; set; }
		public double Electricity { get; set; }
		public double Kerosene { get; set; }
		public FuelPrices()
		{
			Petrol = 0;
			Diesel = 0;
			Gas = 0;
			Electricity = 0;
			Kerosene = 0;
		}
	}
}
