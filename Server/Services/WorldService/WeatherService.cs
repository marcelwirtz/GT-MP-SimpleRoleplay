using GrandTheftMultiplayer.Server.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleRoleplay.Server.Services.WorldService
{
	class WeatherService
	: Script
	{
		public WeatherService()
		{
			API.onResourceStart += OnResourceStartHandler;
			API.onResourceStop += OnResourceStopHandler;
		}

		public static Timer WeatherTimer;

		public void OnResourceStartHandler()
		{
			StartWeatherTimer();
		}

		public void OnResourceStopHandler()
		{
			API.stopTimer(WeatherTimer);
		}

		public static void StartWeatherTimer()
		{
			Random rnd = new Random();
			int minutes = rnd.Next(30, 120);
			int nextweather = rnd.Next(0, 9);
			WeatherTimer = API.shared.delay(minutes * 60 * 1000, true, () =>
			{
				ChangeWeather(nextweather);
			});
			API.shared.consoleOutput("WEATHER: Next Weather in " + minutes + " minutes is ID: " + nextweather);
		}

		public static void ChangeWeather(int weatherId)
		{
			API.shared.triggerClientEventForAll("Weather_StartTansition", weatherId, 300);
			API.shared.delay(300000, true, () =>
			{
				API.shared.setWeather(weatherId);
				StartWeatherTimer();
			});
		}

		public static void ChangeWeatherOnce(int weatherId)
		{
			API.shared.triggerClientEventForAll("Weather_StartTansition", weatherId, 300);
			API.shared.delay(300000, true, () =>
			{
				API.shared.setWeather(weatherId);
			});
		}
	}
}
