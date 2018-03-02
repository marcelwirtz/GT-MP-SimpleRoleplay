/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />
API.onServerEventTrigger.connect(function (eventName, args) {
	if (eventName == "SpawnMenu_Open") {
		
	}
	switch (eventName) {
		case "SpawnMenu_Open":
			SpawnJson = JSON.parse(args[0]);
			CreateSpawnMenu();
			SpawnMenu.Visible = true;
			API.attachCameraToEntity(SpawnCamera, API.getLocalPlayer(), new Vector3(0, 0, SpawnCameraHeight));
			API.pointCameraAtEntity(SpawnCamera, API.getLocalPlayer(), new Vector3(0, 0, 0));
			API.setActiveCamera(SpawnCamera);
			API.callNative("0xA0EBB943C300E693", false);
			API.setCanOpenChat(false);
			break;
		case "SpawnMenu_Close":
			API.fadeScreenOut(500);
			API.setCameraPosition(SecondSpawnCamera, API.getEntityAbovePosition(API.getLocalPlayer()));
			API.interpolateCameras(SpawnCamera, SecondSpawnCamera, 700, true, false);
			API.after(1000, "SpawnFadeScreenIn");
			break;
		case "SpawnMovePed":
			SpawnPedMoving = true;
			API.after(1000, "SpawnStopMoving");
			break;
	}

});
var SpawnPedMoving = false;
var SpawnCameraHeight = 500;
var SpawnMenu = API.createMenu("Spawn Menu", "", 0, 0, 6);
var SpawnCamera = API.createCamera(new Vector3(0, 0, SpawnCameraHeight), new Vector3(0, 0, 0));
var SecondSpawnCamera = API.createCamera(new Vector3(0, 0, 0), new Vector3(-90, 0, 0));
var SpawnJson;

function SpawnStopMoving() {
	SpawnPedMoving = false;
}

function CreateSpawnMenu() {
	SpawnMenu.Clear();
	for (var i = 0; i < SpawnJson.length; i++) {
		var SpawnObj = SpawnJson[i];
		SpawnMenu.AddItem(API.createMenuItem(SpawnObj['Name'], ""));
		SpawnMenu.ResetKey(menuControl.Back);
	}
}

SpawnMenu.OnIndexChange.connect(function (menu, index) {
	API.triggerServerEvent("SpawnMove", index);
});

SpawnMenu.OnItemSelect.connect(function (menu, item, index) {
	if (!SpawnPedMoving) {
		API.triggerServerEvent("SpawnSelected", index);
	}
});

function SpawnFadeScreenIn() {
	API.setActiveCamera(null);
	SpawnMenu.Visible = false;
	SpawnMenu.Clear();
	API.callNative("0xA0EBB943C300E693", true);
	API.setCanOpenChat(true);
	API.fadeScreenIn(1000);
}