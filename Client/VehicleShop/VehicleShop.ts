/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />

var VehicleShopMenu = API.createMenu("Vehicle Shop", "Available Vehicles:", 0, 0, 6);

var VehicleShopJson;
var VehicleShopPreviewPosition = new Vector3();
var VehicleShopPreviewRotation = new Vector3();
var VehicleShopPreviewCamera = API.createCamera(new Vector3(), new Vector3());
var VehicleShopPreviewVehicle = null;
var currentindex = 0;
//var info_panel = API.requestScaleform("mp_results_panel");
var info_panel = API.requestScaleform("mp_car_stats_01");
var res = API.getScreenResolutionMaintainRatio();

API.onServerEventTrigger.connect(function (eventName, args) {
	switch (eventName) {
		case "VehicleShop_OpenMenu":
			API.closeAllMenus();
			VehicleShopJson = JSON.parse(args[0]);
			VehicleShopPreviewPosition = args[1];
			VehicleShopPreviewRotation = args[2];
			API.setCameraPosition(VehicleShopPreviewCamera, args[3]);
			API.pointCameraAtPosition(VehicleShopPreviewCamera, VehicleShopPreviewPosition);
			API.setMenuTitle(VehicleShopMenu, args[4]);
			VehicleShopFillMenu();
			API.setActiveCamera(VehicleShopPreviewCamera);
			currentindex = 0
			VehicleShopMenu.Visible = true;
			break;
		case "VehicleShop_CloseMenu":
			VehicleShopMenu.Visible = false;
			if (VehicleShopPreviewVehicle != null) {
				API.deleteEntity(VehicleShopPreviewVehicle);
				VehicleShopPreviewVehicle = null;
				API.setActiveCamera(null);
			}
			break;
	}
});

function VehicleShopFillMenu() {
	VehicleShopMenu.Clear();
	for (var i = 0; i < VehicleShopJson.length; i++) {
		var vehicleShopObj = VehicleShopJson[i];
		var NewItem = API.createMenuItem(API.getVehicleDisplayName(vehicleShopObj["VehHash"]), "");
		NewItem.SetRightLabel(vehicleShopObj["Description"]);
		VehicleShopMenu.AddItem(NewItem);
	}
	if (VehicleShopPreviewVehicle != null) {
		API.deleteEntity(VehicleShopPreviewVehicle);
		VehicleShopPreviewVehicle = null;
	}
	// First Vehilce on Loading
	VehicleShopPreviewVehicle = API.createVehicle(VehicleShopJson[0]["VehHash"], VehicleShopPreviewPosition, VehicleShopPreviewRotation);
	API.setVehiclePrimaryColor(VehicleShopPreviewVehicle, 111);
	API.setVehicleSecondaryColor(VehicleShopPreviewVehicle, 111);
	VehicleShopInfoPanel(API.getVehicleDisplayName(VehicleShopJson[0]["VehHash"]), VehicleShopJson[0]["Description"], VehicleShopJson[0]["InfoFuel"], VehicleShopJson[0]["InfoStorage"], VehicleShopJson[0]["VehHash"])
}

function VehicleShopInfoPanel(title, subtitle, row1, row2, vehHash) {
	/*info_panel.CallFunction("SET_TITLE", title);
	info_panel.CallFunction("SET_SUBTITLE", "Price: ~g~" + subtitle);
	info_panel.CallFunction("SET_SLOT", 1, 0, "Fuel: " + row1);
	info_panel.CallFunction("SET_SLOT", 2, 0, "Storage: " + row2);
	info_panel.CallFunction("SET_SLOT", 3, 0, "Max Speed: " + row3 + " KM/H");*/
	info_panel.CallFunction("SET_VEHICLE_INFOR_AND_STATS", title, "Fuel Type: " + row1 + " | Storage: " + row2, "MPCarHUD", "Cheval", "Top Speed", "Braking", "Traction", "Acceleration", Math.round(API.getVehicleMaxSpeed(vehHash) * 1.2), Math.round(API.getVehicleMaxBraking(vehHash) * 40), Math.round(API.getVehicleMaxTraction(vehHash) * 20), Math.round(API.getVehicleMaxAcceleration(vehHash) * 40));
//SET_VEHICLE_INFOR_AND_STATS(vehicleInfo, vehicleDetails, logoTXD, logoTexture, statStr1, statStr2, statStr3, statStr4, statVal1, statVal2, statVal3, statVal4)

}

VehicleShopMenu.OnItemSelect.connect(function (menu, item, index) {
	API.triggerServerEvent("VehicleShop_BuyVehicle", VehicleShopJson[index]["Name"]);
});

VehicleShopMenu.OnMenuClose.connect(function (menu) {
	if (VehicleShopPreviewVehicle != null) {
		API.deleteEntity(VehicleShopPreviewVehicle);
		VehicleShopPreviewVehicle = null;
	}
	API.setActiveCamera(null);
});

VehicleShopMenu.OnIndexChange.connect(function (menu, index) {
	if (VehicleShopPreviewVehicle != null) {
		API.deleteEntity(VehicleShopPreviewVehicle);
		VehicleShopPreviewVehicle = null;
	}
	VehicleShopPreviewVehicle = API.createVehicle(VehicleShopJson[index]["VehHash"], VehicleShopPreviewPosition, VehicleShopPreviewRotation);
	API.setVehiclePrimaryColor(VehicleShopPreviewVehicle, 111);
	API.setVehicleSecondaryColor(VehicleShopPreviewVehicle, 111);
	VehicleShopInfoPanel(API.getVehicleDisplayName(VehicleShopJson[index]["VehHash"]), VehicleShopJson[index]["Description"], VehicleShopJson[index]["InfoFuel"], VehicleShopJson[index]["InfoStorage"], VehicleShopJson[index]["VehHash"])
	currentindex = index;
});

API.onUpdate.connect(function () {
	if (VehicleShopMenu.Visible) {
		//v1
		//API.renderScaleform(info_panel, (res.Width / 2) - 725, 450, 900, 600);

		//v2
		API.renderScaleform(info_panel, 0, 11, 1280, 720);

		//v2 3D
		//var camrot = API.getCameraRotation(VehicleShopPreviewCamera);
		//var modeldimensions = API.getModelDimensions(VehicleShopJson[currentindex]["VehHash"]);
		//var pos3d = new Vector3(VehicleShopPreviewPosition.X, VehicleShopPreviewPosition.Y, VehicleShopPreviewPosition.Z + 1.75 + modeldimensions.Maximum.Z);
		
		//API.callNative("_DRAW_SCALEFORM_MOVIE_3D_NON_ADDITIVE", info_panel.Handle, API.f(pos3d.X), API.f(pos3d.Y), API.f(pos3d.Z), API.f(camrot.X), API.f(camrot.Y), API.f(360 - camrot.Z), API.f(2), API.f(2), API.f(1), API.f(6), API.f(3), API.f(1), 2);
	}
}); 