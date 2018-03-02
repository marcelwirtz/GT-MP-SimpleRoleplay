﻿/// <reference path="../../../types-gt-mp/Definitions/index.d.ts" /> 
 
var PoliceWeaponMenu = API.createMenu("Cop Weapons", "", 0, 0, 6); 
var PoliceWeaponJson; 
 
API.onServerEventTrigger.connect(function (eventName, args) { 
  switch (eventName) { 
	case "Police_OpenWeaponMenu": 
	  API.closeAllMenus(); 
	  PoliceWeaponJson = JSON.parse(args[0]); 
	  FillPoliceWeaponMenu(); 
	  PoliceWeaponMenu.Visible = true; 
	  break; 
	case "Police_CloseWeaponMenu": 
	  API.closeAllMenus(); 
	  break; 
  } 
}); 
 
 
function FillPoliceWeaponMenu() { 
	PoliceWeaponMenu.Clear(); 
	for (var i = 0; i < PoliceWeaponJson.length; i++) { 
	  var MenuObj = PoliceWeaponJson[i]; 
	var NewItem = API.createMenuItem(MenuObj["Title"], MenuObj["Description"]); 
	if (MenuObj["RightLabel"] != "") { 
	  NewItem.SetRightLabel(MenuObj["RightLabel"]); 
	} 
	PoliceWeaponMenu.AddItem(NewItem); 
  } 
} 
 
PoliceWeaponMenu.OnItemSelect.connect(function (menu, item, index) { 
	API.triggerServerEvent("Police_WeaponMenuItemSelected", PoliceWeaponJson[index]["Value1"]) 
});