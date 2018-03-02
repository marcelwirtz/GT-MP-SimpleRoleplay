using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class VehicleShopMenuItem
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int VehHash { get; set; }
		public string InfoFuel { get; set; }
		public string InfoStorage { get; set; }
		public string InfoMaxSpeed { get; set; }
	}
}
