"use strict";
var RefuelProgressbarVisible = false;
var res = API.getScreenResolutionMaintainRatio();
var BarStepSize = (res.Width / 2) / 100;
var StartFuel = 0;
var CurrentFuel = 0;
var MaxFuel = 100;
var LocalPlayer = API.getLocalPlayer();
var PercentPerLiter = 0;
API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "ShowRefuelProgressbar":
            LocalPlayer = API.getLocalPlayer();
            StartFuel = args[0];
            MaxFuel = args[1];
            CurrentFuel = API.getEntitySyncedData(LocalPlayer, "currentfuel");
            PercentPerLiter = 100 / (MaxFuel - StartFuel);
            RefuelProgressbarVisible = true;
            break;
        case "HideRefuelProgressbar":
            RefuelProgressbarVisible = false;
            break;
    }
});
API.onUpdate.connect(function () {
    if (RefuelProgressbarVisible) {
        DrawRefuelProgressbar();
    }
});
function DrawRefuelProgressbar() {
    CurrentFuel = API.getEntitySyncedData(LocalPlayer, "currentfuel");
    var percentage = Math.round((CurrentFuel - StartFuel) * PercentPerLiter);
    API.drawRectangle((res.Width / 2) - (res.Width / 4) - 3, (res.Height / 6) - 3, (res.Width / 2) + 6, 56, 0, 0, 0, 150);
    API.drawRectangle((res.Width / 2) - (res.Width / 4), (res.Height / 6), percentage * BarStepSize, 50, 150, 200, 255, 150);
    API.drawText(percentage + "% (" + CurrentFuel + "L/" + MaxFuel + "L)", (res.Width / 2), (res.Height / 6) + 4, 0.5, 255, 255, 255, 255, 0, 1, false, true, 250);
}
