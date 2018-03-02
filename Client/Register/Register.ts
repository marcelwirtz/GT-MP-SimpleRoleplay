/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />
API.onServerEventTrigger.connect(function (eventName, args) {
	switch (eventName) {
		case "setRegisterUiVisible":
			RegisterUIOpen = args[0];
			if (args[0]) {
				API.setCanOpenChat(false);
				cursorIndex = 0;
				API.disableVehicleEnteringKeys(true);
				API.disableAlternativeMainMenuKey(true);
				//API.setHudVisible(false);
				API.callNative("0xA0EBB943C300E693", false);
				RegisterCamera = API.createCamera(args[1], new Vector3(0, 0, 0));
				API.pointCameraAtPosition(RegisterCamera, args[2]);
				API.setActiveCamera(RegisterCamera);
				minPasswordLength = args[3];
			} else {
				API.after(1000, "CloseRegisterStep1");
				API.after(1200, "CLoseRegisterStep2");
			}
			break;
	}
});

function CloseRegisterStep1() {
	API.setCanOpenChat(true);
	API.disableVehicleEnteringKeys(false);
	API.disableAlternativeMainMenuKey(false);
	API.setActiveCamera(null);
	API.setHudVisible(true);
}

function CLoseRegisterStep2() {
	API.fadeScreenIn(1000);
}

API.onUpdate.connect(function () {
	if (RegisterUIOpen) {
		DrawRegisterScreen();
		API.disableAllControlsThisFrame();
	}
});

var RegisterCamera = null;

// Vars
var RegisterUIOpen = false;

var firstpassword = "";
var password = "";

var firstPasswordPlaceholder = "Enter Password";
var passwordPlaceholder = "ReEnter Password";

var res = API.getScreenResolutionMaintainRatio();
var safe = (res.Height / 4);
var posX = safe * 2.5;
var posY = safe;
var Width = res.Width - (5 * safe);
var Height = 2 * safe;

var FirstPasswordY = posY + 170;
var PasswordY = posY + 290;

var defaultTextBoxBg = new Vector3(241, 241, 241);
var highlightTextBoxBg = new Vector3(183, 255, 96);

var defaultButtonBg = new Vector3(55, 55, 55);
var highlightButtonBg = new Vector3(122, 122, 122);

var cursorIndex = 0;

var ErrorMessage = "";

var minPasswordLength = 4;

function DrawRegisterScreen() {
	// Background
	API.drawRectangle(posX, posY, Width, Height, 30, 30, 30, 240);
	// Header
	API.drawText("Register", posX + (Width / 2), posY + 20, 2, 255, 255, 255, 255, 1, 1, false, false, 500);

	// FirstPassword Text
	API.drawText("Password", posX + 50, FirstPasswordY, 0.7, 255, 255, 255, 255, 4, 0, false, false, 500);
	// FirstPassword BoxBackground
	if (cursorIndex == 0) {
		API.drawRectangle(posX + 50, FirstPasswordY + 50, Width - 100, 50, highlightTextBoxBg.X, highlightTextBoxBg.Y, highlightTextBoxBg.Z, 255);
	} else {
		API.drawRectangle(posX + 50, FirstPasswordY + 50, Width - 100, 50, defaultTextBoxBg.X, defaultTextBoxBg.Y, defaultTextBoxBg.Z, 255);
	}
	// FirstPassword BoxText
	if (firstpassword.length == 0) {
		API.drawText(firstPasswordPlaceholder, posX + 60, FirstPasswordY + 50, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
	} else {
		API.drawText(firstpassword.replace(/./g, "*"), posX + 60, FirstPasswordY + 60, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
	}

	// Password Text
	API.drawText("ReEnter Password", posX + 50, PasswordY, 0.7, 255, 255, 255, 255, 4, 0, false, false, 500);
	// Password BoxBackground
	if (cursorIndex == 1) {
		API.drawRectangle(posX + 50, PasswordY + 50, Width - 100, 50, highlightTextBoxBg.X, highlightTextBoxBg.Y, highlightTextBoxBg.Z, 255);
	} else {
		API.drawRectangle(posX + 50, PasswordY + 50, Width - 100, 50, defaultTextBoxBg.X, defaultTextBoxBg.Y, defaultTextBoxBg.Z, 255);
	}
	// Password BoxText
	if (password.length == 0) {
		API.drawText(passwordPlaceholder, posX + 60, PasswordY + 50, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
	} else {
		API.drawText(password.replace(/./g, "*"), posX + 60, PasswordY + 60, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
	}

	// Button Background
	if (cursorIndex == 2) {
		API.drawRectangle(posX + 50, PasswordY + 130, Width - 100, 65, highlightButtonBg.X, highlightButtonBg.Y, highlightButtonBg.Z, 240);
	} else {
		API.drawRectangle(posX + 50, PasswordY + 130, Width - 100, 65, defaultButtonBg.X, defaultButtonBg.Y, defaultButtonBg.Z, 240);
	}
	// Button Text
	API.drawText("Register", posX + (Width / 2), PasswordY + 135, 0.7, 255, 255, 255, 255, 4, 1, false, false, 500);

	if (ErrorMessage != "") {
		API.drawText("ERROR: " + ErrorMessage, posX + 50, PasswordY + 200, 0.5, 255, 0, 0, 255, 4, 0, false, false, 500);
	}
	
}

API.onKeyDown.connect(function (sender, e) {
	if (RegisterUIOpen) {
			switch (e.KeyCode) {
				case Keys.Tab:
					switch (cursorIndex) {
						case 0:
							cursorIndex = 1;
							break;
						case 1:
							cursorIndex = 2;
							break;
						case 2:
							cursorIndex = 0;
							break;
					}
					break;
				case Keys.Up:
					if (cursorIndex == 0) {
						cursorIndex = 2;
					} else {
						cursorIndex--;
					}
					break;
				case Keys.Down:
					if (cursorIndex == 2) {
						cursorIndex = 0;
					} else {
						cursorIndex++;
					}
					break;
				case Keys.Enter:
					if (cursorIndex == 2) {
						RegisterButtonTriggered();
					}
					break;
				case Keys.Back:
					switch (cursorIndex) {
						case 0: // Password
							if (firstpassword.length != 0) {
								firstpassword = firstpassword.substring(0, firstpassword.length - 1);
							}
							if (firstpassword.length < minPasswordLength) {
								ErrorMessage = "The password must be at least " + minPasswordLength + " characters long!";
							} else {
								ErrorMessage = "";
							}
							break;
						case 1: // ReEnter Password
							if (password.length != 0) {
								password = password.substring(0, password.length - 1);
							}

							if (password == firstpassword) {
								ErrorMessage = "";
							} else {
								ErrorMessage = "Passwords doesn't match!";
							}
							break;
					}
					break;
				default:
					switch (cursorIndex) {
						case 0: // Password
							firstpassword += API.getCharFromKey(e.KeyValue, e.Shift, e.Control, e.Alt);
							if (firstpassword.length < minPasswordLength) {
								ErrorMessage = "The password must be at least " + minPasswordLength + " characters long!";
							} else {
								ErrorMessage = "";
							}
							break;
						case 1: // ReEnter Password
							password += API.getCharFromKey(e.KeyValue, e.Shift, e.Control, e.Alt);
							if (password == firstpassword) {
								ErrorMessage = "";
							} else {
								ErrorMessage = "Passwords doesn't match!";
							}
							break;
					}
					break;
			}
	}
})

function RegisterButtonTriggered() {
	if (firstpassword == password) {
		if (firstpassword.length >= minPasswordLength) {
			RegisterUIOpen = false;
			API.setCanOpenChat(true);
			API.triggerServerEvent("account_registerButtonPressed", firstpassword, password);
			ErrorMessage = "";
		} else {
			ErrorMessage = "The password must be at least " + minPasswordLength + " characters long!";
		}
	} else {
		ErrorMessage = "Passwords doesn't match!";
	}
	
}