"use strict";
API.onResourceStart.connect(function () {
    var players = API.getStreamedPlayers();
    for (var i = players.Length - 1; i >= 0; i--) {
        setPedCharacter(players[i]);
    }
});
API.onServerEventTrigger.connect(function (name, args) {
    if (name == "UPDATE_CHARACTER") {
        setPedCharacter(args[0]);
    }
});
API.onEntityStreamIn.connect(function (ent, entType) {
    if (entType == 6 || entType == 8) {
        setPedCharacter(ent);
    }
});
function setPedCharacter(ent) {
    if (API.isPed(ent) &&
        API.getEntitySyncedData(ent, "CHAR_HAS_CHARACTER_DATA") === true &&
        (API.getEntityModel(ent) == 1885233650 ||
            API.getEntityModel(ent) == -1667301416)) {
        var shapeFirstId = API.getEntitySyncedData(ent, "CHAR_FATHER");
        var shapeSecondId = API.getEntitySyncedData(ent, "CHAR_MOTHER");
        var skinFirstId = API.getEntitySyncedData(ent, "CHAR_FATHER");
        var skinSecondId = API.getEntitySyncedData(ent, "CHAR_MOTHER");
        var shapeMix = API.getEntitySyncedData(ent, "CHAR_SIMILARITY");
        var skinMix = API.getEntitySyncedData(ent, "CHAR_SKIN_SIMILARITY");
        API.setPlayerHeadBlendData(ent, shapeFirstId, shapeSecondId, 0, skinFirstId, skinSecondId, 0, shapeMix, skinMix, 0, false);
        var hairColor = API.getEntitySyncedData(ent, "CHAR_HAIR_COLOR");
        var highlightColor = API.getEntitySyncedData(ent, "CHAR_HAIR_HIGHLIGHT_COLOR");
        API.setPlayerHairColor(ent, hairColor, highlightColor);
        var eyeColor = API.getEntitySyncedData(ent, "CHAR_EYE_COLOR");
        API.setPlayerEyeColor(ent, eyeColor);
        var eyebrowsStyle = API.getEntitySyncedData(ent, "CHAR_EYEBROWS");
        var eyebrowsColor = API.getEntitySyncedData(ent, "CHAR_EYEBROW_COLOR");
    }
}
