"use strict";
var GarageJson;
var GarageMenu = API.createMenu("Garage", "", 0, 0, 6);
var ParkOutItem = API.createMenuItem("Park Out Vehicle", "");
var ParkItem = API.createMenuItem("Park Vehicle", "");
GarageMenu.AddItem(ParkOutItem);
GarageMenu.AddItem(ParkItem);
var GarageSubMenu = API.createMenu("Your Vehicles", "Available Vehicles:", 0, 0, 6);
GarageMenu.BindMenuToItem(GarageSubMenu, ParkOutItem);
function FillGarageSubMenu() {
    GarageSubMenu.Clear();
    for (var i = 0; i < GarageJson.length; i++) {
        var GarageObj = GarageJson[i];
        var NewItem = API.createMenuItem(API.getVehicleDisplayName(GarageObj["VehHash"]) + " (" + GarageObj["NumberPlate"] + ")", GarageObj["Description"]);
        GarageSubMenu.AddItem(NewItem);
    }
}
GarageSubMenu.OnItemSelect.connect(function (menu, item, index) {
    API.triggerServerEvent("Garage_UseVehicle", GarageJson[index]["Id"]);
});
GarageMenu.OnItemSelect.connect(function (menu, item, index) {
    if (item == ParkItem) {
        API.triggerServerEvent("Garage_ParkVehicle");
    }
});
API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "Garage_OpenMenu":
            API.closeAllMenus();
            GarageJson = JSON.parse(args[0]);
            FillGarageSubMenu();
            GarageMenu.Visible = true;
            break;
        case "Garage_CloseMenu":
            GarageSubMenu.Visible = false;
            GarageMenu.Visible = false;
            break;
    }
});
