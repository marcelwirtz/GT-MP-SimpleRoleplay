"use strict";
var isCuffed = false;
var player = null;
var lastRagdollAnimationChangeRequested = Math.abs(Date.now() - 3000);
API.onServerEventTrigger.connect(function (eventName, args) {
    player = API.getLocalPlayer();
    if (eventName == "Client_Cuffed") {
        isCuffed = args[0];
    }
});
API.onUpdate.connect(function () {
    if (isCuffed) {
        CriminalIsCuffed();
    }
});
function CriminalIsCuffed() {
    var vehicle = API.getPlayerVehicle(player);
    API.disableControlThisFrame(12);
    API.disableControlThisFrame(13);
    API.disableControlThisFrame(14);
    API.disableControlThisFrame(15);
    API.disableControlThisFrame(16);
    API.disableControlThisFrame(17);
    API.disableControlThisFrame(24);
    API.disableControlThisFrame(25);
    API.disableControlThisFrame(47);
    API.disableControlThisFrame(58);
    API.disableControlThisFrame(59);
    API.disableControlThisFrame(63);
    API.disableControlThisFrame(66);
    API.disableControlThisFrame(68);
    API.disableControlThisFrame(69);
    API.disableControlThisFrame(70);
    API.disableControlThisFrame(86);
    API.disableControlThisFrame(89);
    API.disableControlThisFrame(90);
    API.disableControlThisFrame(91);
    API.disableControlThisFrame(92);
    API.disableControlThisFrame(107);
    API.disableControlThisFrame(108);
    API.disableControlThisFrame(109);
    API.disableControlThisFrame(110);
    API.disableControlThisFrame(111);
    API.disableControlThisFrame(112);
    API.disableControlThisFrame(114);
    API.disableControlThisFrame(140);
    API.disableControlThisFrame(141);
    API.disableControlThisFrame(142);
    API.disableControlThisFrame(257);
    API.disableControlThisFrame(263);
    API.disableControlThisFrame(264);
    API.disableControlThisFrame(331);
    if (!API.isPlayerRagdoll(player) && (API.getAnimCurrentTime(player, "mp_arresting", "idle") == -1 || API.getAnimCurrentTime(player, "mp_arresting", "idle") == 0.00000000)
        && Math.abs(Date.now() - lastRagdollAnimationChangeRequested) > 3000) {
        lastRagdollAnimationChangeRequested = Date.now();
        API.triggerServerEvent("Police_ApplyCuffedAnimation");
    }
    if (API.isPlayerInAnyVehicle(player) && API.getPlayerVehicleSeat(player) != -1) {
        if (CriminalisPoliceVehicle(vehicle)) {
            API.disableControlThisFrame(75);
        }
    }
    function CriminalisPoliceVehicle(vehicle) {
        var model = API.getEntityModel(vehicle);
        switch (model) {
            case 2046537925:
            case -1627000575:
            case 1912215274:
            case -1973172295:
            case 456714581:
            case -1683328900:
            case 1922257928:
            case -34623805:
            case 353883353:
                return true;
            default:
                return false;
        }
    }
}
