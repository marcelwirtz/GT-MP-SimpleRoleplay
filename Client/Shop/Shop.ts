/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />

var ShopBuyMenu = null;
var ShopSellMenu = null;
var ShopMenu = null;
var ShopJson;
var ShopSellJson;
var ShopBuyItem;
var ShopSellItem;
var ShopMenuImage = "";

API.onResourceStart.connect(function () {
	ShopBuyMenu = API.createMenu(" ", "Shop Buy", 0, 0, 6);
	ShopSellMenu = API.createMenu(" ", "Shop Sell", 0, 0, 6);
	ShopMenu = API.createMenu(" ", "", 0, 0, 6);

	API.setMenuBannerTexture(ShopBuyMenu, "Client/MenuImages/shopui_title_24-7.jpg");
	API.setMenuBannerTexture(ShopSellMenu, "Client/MenuImages/shopui_title_24-7.jpg");
	API.setMenuBannerTexture(ShopMenu, "Client/MenuImages/shopui_title_24-7.jpg");

	ShopBuyItem = API.createMenuItem("Buy", "");
	ShopMenu.AddItem(ShopBuyItem);
	ShopMenu.BindMenuToItem(ShopBuyMenu, ShopBuyItem);

	ShopSellItem = API.createMenuItem("Sell", "");
	ShopMenu.AddItem(ShopSellItem);
	ShopMenu.BindMenuToItem(ShopSellMenu, ShopSellItem);

	ShopBuyMenu.OnItemSelect.connect(function (menu, item, index) {
		API.triggerServerEvent("ShopBuyItem", ShopJson[index]["Id"]);
	});

	ShopSellMenu.OnItemSelect.connect(function (menu, item, index) {
		API.triggerServerEvent("ShopSellItem", ShopSellJson[index]["Id"]);
	});
});

API.onServerEventTrigger.connect(function (eventName, args) {
	switch (eventName) {

		case "Shop_OpenMenu":
			API.closeAllMenus();
			ShopJson = JSON.parse(args[0]);
			ShopSellJson = JSON.parse(args[1]);
			SetMenuImage(args[2]);
			FillShopMenu();
			FillShopSellMenu();
			ShopMenu.Visible = true;
			break;
		case "Shop_CloseMenu":
			ShopBuyMenu.Visible = false;
			ShopMenu.Visible = false;
			break;
		case "Shop_RefreshShopMenu":
			ShopJson = JSON.parse(args[0]);
			ShopSellJson = JSON.parse(args[1]);
			FillShopMenu();
			FillShopSellMenu();
			break;
	}
});

function SetMenuImage(image) {
	if (image == "") {
		API.setMenuBannerTexture(ShopBuyMenu, "Client/MenuImages/shopui_title_24-7.jpg");
		API.setMenuBannerTexture(ShopSellMenu, "Client/MenuImages/shopui_title_24-7.jpg");
		API.setMenuBannerTexture(ShopMenu, "Client/MenuImages/shopui_title_24-7.jpg");
	} else {
		API.setMenuBannerTexture(ShopBuyMenu, "Client/MenuImages/" + image);
		API.setMenuBannerTexture(ShopSellMenu, "Client/MenuImages/" + image);
		API.setMenuBannerTexture(ShopMenu, "Client/MenuImages/" + image);
	}
}

function FillShopMenu() {
	ShopBuyMenu.Clear();
	for (var i = 0; i < ShopJson.length; i++) {
		var ShopObj = ShopJson[i];
		var NewItem = API.createMenuItem(ShopObj["Name"], "");
		if (ShopObj["Count"] == 0) {
			var RightLabel = "~r~Sold Out";
		} else {
			var RightLabel = ShopObj["BuyPrice"] + " $";
		}
		NewItem.SetRightLabel(RightLabel);
		ShopBuyMenu.AddItem(NewItem);
	}
}

function FillShopSellMenu() {
	ShopSellMenu.Clear();
	for (var i = 0; i < ShopSellJson.length; i++) {
		var ShopInvObj = ShopSellJson[i];
		if (ShopInvObj["Count"] != 0) {
			var NewItem = API.createMenuItem(ShopInvObj["Name"], "~b~each ~w~" + ShopInvObj["Description"] + " ~g~$");

			NewItem.SetRightLabel(ShopInvObj["Count"] + "x");
			ShopSellMenu.AddItem(NewItem);
		}
	}
}


