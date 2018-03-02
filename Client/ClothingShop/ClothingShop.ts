/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />

var ClothingShopMainMenu = API.createMenu("Clothing Shop", "Available Categories:", 0, 0, 6);
var ClothingShopTops = API.createMenuItem("Tops", "");
var ClothingShopLegs = API.createMenuItem("Legs", "");
var ClothingShopFeets = API.createMenuItem("Feets", "");
var ClothingShopJson;

var ClothingShopTopMenu = API.createMenu("Tops", "Available Tops:", 0, 0, 6);
var ClothingShopLegMenu = API.createMenu("Legs", "Available Legs:", 0, 0, 6);
var ClothingShopFeetMenu = API.createMenu("Feets", "Available Feets:", 0, 0, 6);

ClothingShopMainMenu.BindMenuToItem(ClothingShopTopMenu, ClothingShopTops);
ClothingShopMainMenu.BindMenuToItem(ClothingShopLegMenu, ClothingShopLegs);
ClothingShopMainMenu.BindMenuToItem(ClothingShopFeetMenu, ClothingShopFeets);

API.onServerEventTrigger.connect(function (eventName, args) {
	switch (eventName) {
		case "ClothingShop_OpenMenu":
			API.closeAllMenus();
			ClothingShopJson = JSON.parse(args[0]);
			FillClothingShopMenu();
			ClothingShopMainMenu.Visible = true;
			break;
		case "ClothingShop_CloseMenu":
			ClothingShopMainMenu.Visible = false;
			ClothingShopTopMenu.Visible = false;
			ClothingShopLegMenu.Visible = false;
			ClothingShopFeetMenu.Visible = false;
			break;
	}
});

function FillClothingShopMenu() {
	ClothingShopMainMenu.Clear();
	ClothingShopTopMenu.Clear();
	ClothingShopLegMenu.Clear();
	ClothingShopFeetMenu.Clear();

	if (ClothingShopJson["AvailableTops"].length != 0) {
		ClothingShopMainMenu.AddItem(ClothingShopTops);
	}

	for (var i = 0; i < ClothingShopJson["AvailableTops"].length; i++) {
		var menuObj = ClothingShopJson["AvailableTops"][i];
		var NewItem = API.createMenuItem(menuObj["Id"] + "", "");
		if (menuObj["AlreadyBought"]) {
			NewItem.SetRightLabel("Already Bought");
		} else {
			NewItem.SetRightLabel(menuObj["Price"] + "$");
		}
		ClothingShopTopMenu.AddItem(NewItem);
	}

	if (ClothingShopJson["AvailableLegs"].length != 0) {
		ClothingShopMainMenu.AddItem(ClothingShopLegs);
	}

	for (var i = 0; i < ClothingShopJson["AvailableLegs"].length; i++) {
		var menuObj = ClothingShopJson["AvailableLegs"][i];
		var NewItem = API.createMenuItem(menuObj["Id"] + "", "");
		if (menuObj["AlreadyBought"]) {
			NewItem.SetRightLabel("Already Bought");
		} else {
			NewItem.SetRightLabel(menuObj["Price"] + "$");
		}
		ClothingShopLegMenu.AddItem(NewItem);
	}

	if (ClothingShopJson["AvailableFeets"].length != 0) {
		ClothingShopMainMenu.AddItem(ClothingShopFeets);
	} 

	for (var i = 0; i < ClothingShopJson["AvailableFeets"].length; i++) {
		var menuObj = ClothingShopJson["AvailableFeets"][i];
		var NewItem = API.createMenuItem(menuObj["Id"] + "", "");
		if (menuObj["AlreadyBought"]) {
			NewItem.SetRightLabel("Already Bought");
		} else {
			NewItem.SetRightLabel(menuObj["Price"] + "$");
		}
		ClothingShopFeetMenu.AddItem(NewItem);
	}
}

ClothingShopMainMenu.OnMenuClose.connect(function (menu) {
	API.triggerServerEvent("ClothingShop_Close");
});

ClothingShopTopMenu.OnMenuClose.connect(function (menu) {
	API.triggerServerEvent("ClothingShop_Close");
});

ClothingShopLegMenu.OnMenuClose.connect(function (menu) {
	API.triggerServerEvent("ClothingShop_Close");
});

ClothingShopFeetMenu.OnMenuClose.connect(function (menu) {
	API.triggerServerEvent("ClothingShop_Close");
});

ClothingShopTopMenu.OnItemSelect.connect(function (menu, item, index) {
	API.triggerServerEvent("ClothingShop_Buy", "top", ClothingShopJson["AvailableTops"][index]["Id"]);
});

ClothingShopTopMenu.OnIndexChange.connect(function (menu, index) {
	API.triggerServerEvent("ClothingShop_Preview", "top", ClothingShopJson["AvailableTops"][index]["Id"]);
});


ClothingShopLegMenu.OnItemSelect.connect(function (menu, item, index) {
	API.triggerServerEvent("ClothingShop_Buy", "leg", ClothingShopJson["AvailableLegs"][index]["Id"]);
});

ClothingShopLegMenu.OnIndexChange.connect(function (menu, index) {
	API.triggerServerEvent("ClothingShop_Preview", "leg", ClothingShopJson["AvailableLegs"][index]["Id"]);
});

ClothingShopFeetMenu.OnItemSelect.connect(function (menu, item, index) {
	API.triggerServerEvent("ClothingShop_Buy", "feet", ClothingShopJson["AvailableFeets"][index]["Id"]);
});

ClothingShopFeetMenu.OnIndexChange.connect(function (menu, index) {
	API.triggerServerEvent("ClothingShop_Preview", "feet", ClothingShopJson["AvailableFeets"][index]["Id"]);
});