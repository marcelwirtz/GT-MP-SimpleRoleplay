"use strict";
var res_X = API.getScreenResolutionMaintainRatio().Width;
API.onUpdate.connect(function () {
    if (API.hasEntitySyncedData(API.getLocalPlayer(), "hud")) {
        if (API.getEntitySyncedData(API.getLocalPlayer(), "hud")) {
            if (API.hasEntitySyncedData(API.getLocalPlayer(), "cash")) {
                API.drawText(API.getEntitySyncedData(API.getLocalPlayer(), "cash") + " $", res_X - 15, 50, 1, 115, 186, 131, 255, 4, 2, false, true, 0);
            }
        }
    }
});
