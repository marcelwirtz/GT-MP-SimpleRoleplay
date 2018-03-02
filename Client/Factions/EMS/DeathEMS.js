"use strict";
var isDeath = false;
API.onResourceStart.connect(function () {
    API.setShowWastedScreenOnDeath(false);
});
API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "EMS_SetPedToRagdoll":
            isDeath = args[0];
            if (args[0]) {
                API.setPedToRagdoll(-1, 0);
            }
            else {
                API.cancelPedRagdoll();
            }
            break;
    }
});
API.onUpdate.connect(function () {
    if (isDeath && !API.isPlayerRagdoll(API.getLocalPlayer())) {
        API.setPedToRagdoll(-1, 0);
    }
});
