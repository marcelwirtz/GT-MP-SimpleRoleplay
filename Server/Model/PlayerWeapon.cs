using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class PlayerWeapon
	{
		public WeaponHash WeaponHash { get; set; }
		public WeaponTint WeaponTint { get; set; }
		public int Ammo { get; set; }
		public WeaponComponent[] WeaponComponents { get; set; }
		public PlayerWeapon()
		{
			WeaponTint = 0;
			Ammo = 0;
			WeaponComponents = new WeaponComponent[] { };
		}
	}
}
