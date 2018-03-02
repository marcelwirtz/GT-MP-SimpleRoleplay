using GrandTheftMultiplayer.Server.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleRoleplay.Server.Services.WorldService
{
	class TimeService
	: Script
	{
		public TimeService()
		{
			API.onResourceStart += OnResourceStartHandler;
			API.onResourceStop += OnResourceStopHandler;
		}

		public Timer TimeTimer;

		public void OnResourceStartHandler()
		{
			TimeTimer = API.startTimer(60000, false, () =>
			{
				API.setTime(DateTime.Now.Hour, DateTime.Now.Minute);
			});
		}

		public void OnResourceStopHandler()
		{
			API.stopTimer(TimeTimer);
		}
	}
}
