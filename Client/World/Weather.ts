/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />
API.onServerEventTrigger.connect(function (eventName, args) {
	if (eventName == "Weather_StartTansition") {
		API.transitionToWeather(args[0], args[1]);
	}
});