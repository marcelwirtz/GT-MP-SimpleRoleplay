"use strict";
API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "fadeScreenIn":
            API.fadeScreenIn(args[0]);
            break;
        case "fadeScreenOut":
            API.fadeScreenOut(args[0]);
            break;
        case "showShard":
            API.showShard(args[0], args[1]);
            break;
        case "showMissionPassedMessage":
            API.showMissionPassedMessage(args[0], args[1]);
            break;
        case "showRankupMessage":
            API.showRankupMessage(args[0], args[1], args[2], args[3]);
            break;
        case "showOldMessage":
            API.showOldMessage(args[0], args[1]);
            break;
        case "showColoredShard":
            API.showColoredShard(args[0], args[1], args[2], args[3], args[4]);
            break;
        case "playScreenEffect":
            API.playScreenEffect(args[0], args[1], args[2]);
            break;
        case "stopScreenEffect":
            API.stopScreenEffect(args[0]);
            break;
        case "stopAllScreenEffects":
            API.stopAllScreenEffects();
            break;
        case "setHudVisible":
            API.setHudVisible(args[0]);
            break;
    }
});
