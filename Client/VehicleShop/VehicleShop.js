"use strict";
var VehicleShopMenu = API.createMenu("Vehicle Shop", "Available Vehicles:", 0, 0, 6);
var VehicleShopJson;
var VehicleShopPreviewPosition = new Vector3();
var VehicleShopPreviewRotation = new Vector3();
var VehicleShopPreviewCamera = API.createCamera(new Vector3(), new Vector3());
var VehicleShopPreviewVehicle = null;
var currentindex = 0;
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
            currentindex = 0;
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
    VehicleShopPreviewVehicle = API.createVehicle(VehicleShopJson[0]["VehHash"], VehicleShopPreviewPosition, VehicleShopPreviewRotation);
    API.setVehiclePrimaryColor(VehicleShopPreviewVehicle, 111);
    API.setVehicleSecondaryColor(VehicleShopPreviewVehicle, 111);
    VehicleShopInfoPanel(API.getVehicleDisplayName(VehicleShopJson[0]["VehHash"]), VehicleShopJson[0]["Description"], VehicleShopJson[0]["InfoFuel"], VehicleShopJson[0]["InfoStorage"], VehicleShopJson[0]["VehHash"]);
}
function VehicleShopInfoPanel(title, subtitle, row1, row2, vehHash) {
    info_panel.CallFunction("SET_VEHICLE_INFOR_AND_STATS", title, "Fuel Type: " + row1 + " | Storage: " + row2, "MPCarHUD", "Cheval", "Top Speed", "Braking", "Traction", "Acceleration", Math.round(API.getVehicleMaxSpeed(vehHash) * 1.2), Math.round(API.getVehicleMaxBraking(vehHash) * 40), Math.round(API.getVehicleMaxTraction(vehHash) * 20), Math.round(API.getVehicleMaxAcceleration(vehHash) * 40));
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
    VehicleShopInfoPanel(API.getVehicleDisplayName(VehicleShopJson[index]["VehHash"]), VehicleShopJson[index]["Description"], VehicleShopJson[index]["InfoFuel"], VehicleShopJson[index]["InfoStorage"], VehicleShopJson[index]["VehHash"]);
    currentindex = index;
});
API.onUpdate.connect(function () {
    if (VehicleShopMenu.Visible) {
        API.renderScaleform(info_panel, 0, 11, 1280, 720);
    }
});
