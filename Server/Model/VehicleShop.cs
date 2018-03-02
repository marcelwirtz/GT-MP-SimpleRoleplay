using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using SimpleRoleplay.Server.Services.FactionService;
using SimpleRoleplay.Server.Services.VehicleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class VehicleShop
	{
		public int Id { get; set; }
		public Vector3 Position { get; set; }
		public float PedHeading { get; set; }
		public Vector3 PreviewPosition { get; set; }
		public Vector3 PreviewRotation { get; set; }
		public Vector3 PreviewCamera { get; set; }
		public VehicleType VehType { get; set; }
		public FactionType FactionType { get; set; }
		public Dictionary<string, double> SellingVehicles { get; set; }
		public int BlipSprite {get; set;}
		public string Name { get; set; }
		public Blip MapMarker { get; set; }
		public Ped Ped { get; set; }
		public VehicleShop()
		{
			Id = 0;
			Position = new Vector3();
			PedHeading = 0;
			PreviewPosition = new Vector3();
			PreviewRotation = new Vector3();
			PreviewCamera = new Vector3();
			VehType = VehicleType.Car;
			FactionType = FactionType.Citizen;
			SellingVehicles = new Dictionary<string, double>();
			BlipSprite = 225;
			Name = "Vehicle Shop";
		}
	}
}
