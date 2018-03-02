using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRoleplay.Server.Model
{
	class MenuItem
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string RightLabel { get; set; }
		public string Value1 { get; set; }
		public string Value2 { get; set; }
		public int Number1 { get; set; }
		public int Number2 { get; set; }
		public MenuItem()
		{
			Title = "";
			Description = "";
			RightLabel = "";
			Value1 = "";
			Value2 = "";
			Number1 = -1;
			Number2 = -1;
		}
	}
}
