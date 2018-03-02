/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />

var GasStationMenu = API.createMenu("Gas Station", "Select Fuel Type:", 0, 0, 6);
var GasStationVehicleMenu = API.createMenu("Gas Station", "Select Vehicle to Refuel:", 0, 0, 6);

var GasStationJson;
var GasStationVehiclesJson;
var SelectedFuelTypeIndex = 0;

API.onServerEventTrigger.connect(function (eventName, args) {
	switch (eventName) {
		case "GasStation_OpenMenu":
			API.closeAllMenus();
			GasStationJson = JSON.parse(args[0]);
			GasStationVehiclesJson = JSON.parse(args[1]);
			GasStationFillMenu();
			GasStationFillVehiclesMenu();
			GasStationMenu.Visible = true;
			SelectedFuelTypeIndex = 0;
			break;
		case "GasStation_CloseMenu":
			GasStationMenu.Visible = false;
			GasStationVehicleMenu.Visible = false;
			SelectedFuelTypeIndex = 0;
			break;
	}
});

function GasStationFillMenu() {
	GasStationMenu.Clear();
	for (var i = 0; i < GasStationJson.length; i++) {
		var gasStationObj = GasStationJson[i];
		var NewItem = API.createMenuItem(gasStationObj["Name"], "");
		if (gasStationObj["SoldOut"]) {
			NewItem.SetRightLabel("~r~SoldOut");
		} else {
			NewItem.SetRightLabel(gasStationObj["RightLabel"]);
		}
		GasStationMenu.AddItem(NewItem);
	}
}

function GasStationFillVehiclesMenu() {
	GasStationVehicleMenu.Clear();
	for (var i = 0; i < GasStationVehiclesJson.length; i++) {
		var GasStationVehObj = GasStationVehiclesJson[i];
		var NewItem = API.createMenuItem(GasStationVehObj["ModelName"] + " (" + GasStationVehObj["NumberPlate"] + ")", "");
		GasStationVehicleMenu.AddItem(NewItem);
	}
}

GasStationMenu.OnItemSelect.connect(function (menu, item, index) {
	if (!GasStationJson[index]["SoldOut"]) {
		SelectedFuelTypeIndex = index;
		menu.Visible = false;
		GasStationVehicleMenu.Visible = true;
	}
});

GasStationVehicleMenu.OnItemSelect.connect(function (menu, item, index) {
	API.triggerServerEvent("GasStation_Begin", GasStationJson[SelectedFuelTypeIndex]["Ident"], GasStationVehiclesJson[index]["Id"]);
});