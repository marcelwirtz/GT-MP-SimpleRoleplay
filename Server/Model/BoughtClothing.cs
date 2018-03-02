using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class BoughtClothing
	{
		public List<int> Tops { get; set; }
		public List<int> Legs { get; set; }
		public List<int> Feets { get; set; }

		public List<int> Masks { get; set; }
		public List<int> Accessories { get; set; }

		public List<int> Hats { get; set; }
		public List<int> Glasses { get; set; }
		public List<int> Ears { get; set; }
		public List<int> Watches { get; set; }
		public List<int> Bracelets { get; set; }

		public BoughtClothing()
		{
			Tops = new List<int>();
			Legs = new List<int>();
			Feets = new List<int>();
			Masks = new List<int>();
			Accessories = new List<int>();
			Hats = new List<int>();
			Glasses = new List<int>();
			Ears = new List<int>();
			Watches = new List<int>();
			Bracelets = new List<int>();
		}
	}
}
