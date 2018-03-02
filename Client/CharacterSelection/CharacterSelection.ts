/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />
API.onServerEventTrigger.connect(function (eventName, args) {
	switch (eventName) {
		case "open_CharacterSelection":
			charselection_menu.Visible = true;
			jsonCharObject = JSON.parse(args[0]);
			SelectionCamera = API.createCamera(args[1], new Vector3());
			API.pointCameraAtPosition(SelectionCamera, args[2]);
			API.setActiveCamera(SelectionCamera);
			API.setCanOpenChat(false);
			CreateMenu();
			API.callNative("0xA0EBB943C300E693", false);
			break;
		case "close_CharacterSelection":
			API.fadeScreenOut(500);
			API.after(1000, "CharSelectionSelected");
			API.after(1200, "CharSelectionFadeIn");
			break;
	}
});
var jsonCharObject;
var charselection_menu = API.createMenu("Character Selection", "", 0, 0, 3);
charselection_menu.ResetKey(menuControl.Back);
var SelectionCamera = null;

function CreateMenu() {
	charselection_menu.Clear();
	for (var i = 0; i < jsonCharObject.length; i++) {
		var charObj = jsonCharObject[i];
		charselection_menu.AddItem(API.createMenuItem(charObj['Name'], ""));
	}
	API.triggerServerEvent("CharacterSelectionPreview", jsonCharObject[0]['Id']);
}

charselection_menu.OnItemSelect.connect(function (menu, item, index) {
	API.triggerServerEvent("CharacterSelectionConfirm", jsonCharObject[index]['Id']);
});

charselection_menu.OnIndexChange.connect(function (menu, index) {
	API.triggerServerEvent("CharacterSelectionPreview", jsonCharObject[index]['Id']);
});

function CharSelectionSelected() {
	charselection_menu.Visible = false;
	API.setActiveCamera(null);
	API.setCanOpenChat(true);
	API.triggerServerEvent("CharacterSelectionFinished");
}
function CharSelectionFadeIn() {
	API.fadeScreenIn(1000);
}