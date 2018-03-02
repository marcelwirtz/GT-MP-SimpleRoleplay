using SimpleRoleplay.Server.Services.VehicleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class GasStationMenuItem
	{
		public string Name { get; set; }
		public string RightLabel { get; set; }
		public bool SoldOut { get; set; }
		public int Ident { get; set; }
	}
}
