/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />
API.onServerEventTrigger.connect(function (eventName, args) {
	if (eventName == "ATM_OpenMenu") {
		ATM_Menu.Visible = true;
		ATM_Player_Bank = args[0];
		API.setMenuSubtitle(ATM_Menu, "~b~Account Balance~w~: " + ATM_Player_Bank + " ~g~$")
	}
	if (eventName == "ATM_CloseMenu") {
		ATM_Menu.Visible = false;
		ATM_AmountItem.SetRightLabel("0");
		ATM_Amount = "0";
		ATM_Player_Bank = 0;
	}
});

var ATM_Menu = API.createMenu("ATM", "", 0, 0, 6);
var ATM_AmountItem = API.createMenuItem("Amount", "");
var ATM_WithdrawItem = API.createMenuItem("~b~Withdraw", ""); // Bank => Cash
var ATM_DepositItem = API.createMenuItem("~g~Deposit", ""); // Cash => Bank
var ATM_Amount = "0";
var ATM_Player_Bank = 0;

ATM_Menu.AddItem(ATM_AmountItem);
ATM_Menu.AddItem(ATM_WithdrawItem);
ATM_Menu.AddItem(ATM_DepositItem);

ATM_AmountItem.SetRightLabel("0");

ATM_Menu.OnItemSelect.connect(function (menu, item, index) {
	switch (item) {
		case ATM_AmountItem:
			ATM_Amount = API.getUserInput("", 10);
			var ATMisValid = /^[0-9,.]*$/.test(ATM_Amount);
			if (ATMisValid) {
				if (ATM_Amount.indexOf('.') !== -1) {
					ATM_AmountItem.SetRightLabel(ATM_Amount + " ~g~$");
				} else {
					ATM_AmountItem.SetRightLabel(ATM_Amount + ".00 ~g~$");
				}
			} else {
				API.sendNotification("~r~Error~w~: Please enter a valid number")
				ATM_Amount = "0";
				ATM_AmountItem.SetRightLabel(ATM_Amount + ".00 ~g~$");
			}
			break;
		case ATM_WithdrawItem:
			API.triggerServerEvent("ATM_Withdraw", ATM_Amount);
			break;
		case ATM_DepositItem:
			API.triggerServerEvent("ATM_Deposit", ATM_Amount);
			break;
	}
});

API.onResourceStart.connect(function () {
	API.setMenuBannerTexture(ATM_Menu, "Client/MenuImages/shopui_title_mazebank.jpg");
});