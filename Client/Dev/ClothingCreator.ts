/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />

var ClothingCreatorMenu = API.createMenu("ClothingTopCreator", "", 0, 0, 6);

var listtops = new List(String);
for (var i = 0; i < 248; i++) {
	listtops.Add("" + i);
}

var listtexture = new List(String);
for (var i = 0; i < 248; i++) {
	listtexture.Add("" + i);
}

var listtorso = new List(String);
for (var i = 0; i < 168; i++) {
	listtorso.Add("" + i);
}

var listundershirt = new List(String);
for (var i = 0; i < 151; i++) {
	listundershirt.Add("" + i);
}

API.onServerEventTrigger.connect(function (eventName, args) {
	switch (eventName) {
		case "open_ClothingCreator":
			ClothingCreatorMenu.Visible = true;
			break;
	}
});

var ClothingItemTops = API.createListItem("Tops", "", listtops, 0);
var ClothingItemTexture = API.createListItem("Top Color", "", listtexture, 0);
var ClothingItemTorso = API.createListItem("Torso", "", listtorso, 0);
var ClothingItemUndershirt = API.createListItem("Undershirt", "", listundershirt, 0);
var ClothingItemSave = API.createMenuItem("~g~Save", "");
var ClothingItemClose = API.createMenuItem("~r~Close", "");

ClothingCreatorMenu.AddItem(ClothingItemTops);
ClothingCreatorMenu.AddItem(ClothingItemTexture);
ClothingCreatorMenu.AddItem(ClothingItemTorso);
ClothingCreatorMenu.AddItem(ClothingItemUndershirt);
ClothingCreatorMenu.AddItem(ClothingItemSave);
ClothingCreatorMenu.AddItem(ClothingItemClose);

ClothingCreatorMenu.OnItemSelect.connect(function (menu, item, index) {
	switch (item) {
		case ClothingItemSave:
			API.triggerServerEvent("save_clothing", ClothingItemTops.Index, ClothingItemTexture.Index, ClothingItemTorso.Index, ClothingItemUndershirt.Index);
			break;
		case ClothingItemClose:
			ClothingCreatorMenu.Visible = false;
			break;
	}
});

ClothingItemTops.OnListChanged.connect(function (item, newIndex) {
	API.setPlayerClothes(API.getLocalPlayer(), 11, newIndex, ClothingItemTexture.Index);
});

ClothingItemTexture.OnListChanged.connect(function (item, newIndex) {
	API.setPlayerClothes(API.getLocalPlayer(), 11, ClothingItemTops.Index, newIndex);
});

ClothingItemTorso.OnListChanged.connect(function (item, newIndex) {
	API.setPlayerClothes(API.getLocalPlayer(), 3, newIndex, 0);
});

ClothingItemUndershirt.OnListChanged.connect(function (item, newIndex) {
	API.setPlayerClothes(API.getLocalPlayer(), 8, newIndex, 0);
});