"use strict";
var ProgressbarVisible = false;
var res = API.getScreenResolutionMaintainRatio();
var BarStepSize = (res.Width / 2) / 100;
var StartUnit = 0;
var CurrentUnits = 0;
var MaxUnits = 100;
var LocalPlayer = API.getLocalPlayer();
var PercentPerUnit = 0;
var ProgressbarLabel = "";
API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "ShowProgressbar":
            LocalPlayer = API.getLocalPlayer();
            StartUnit = args[0];
            MaxUnits = args[1];
            ProgressbarLabel = args[2];
            CurrentUnits = API.getEntitySyncedData(LocalPlayer, "currentprogress");
            PercentPerUnit = 100 / (MaxUnits - StartUnit);
            ProgressbarVisible = true;
            break;
        case "HideProgressbar":
            ProgressbarVisible = false;
            break;
    }
});
API.onUpdate.connect(function () {
    if (ProgressbarVisible) {
        DrawProgressbar();
    }
});
function DrawProgressbar() {
    CurrentUnits = API.getEntitySyncedData(LocalPlayer, "progressbar_progress");
    var percentage = Math.round((CurrentUnits - StartUnit) * PercentPerUnit);
    API.drawRectangle((res.Width / 2) - (res.Width / 4) - 3, (res.Height / 6) - 3, (res.Width / 2) + 6, 56, 0, 0, 0, 150);
    API.drawRectangle((res.Width / 2) - (res.Width / 4), (res.Height / 6), percentage * BarStepSize, 50, 150, 200, 255, 150);
    if (ProgressbarLabel == "") {
        API.drawText(percentage + "%", (res.Width / 2), (res.Height / 6) + 4, 0.5, 255, 255, 255, 255, 0, 1, false, true, (res.Width / 2));
    }
    else {
        API.drawText(percentage + "% - " + ProgressbarLabel, (res.Width / 2), (res.Height / 6) + 4, 0.5, 255, 255, 255, 255, 0, 1, false, true, (res.Width / 2));
    }
}
