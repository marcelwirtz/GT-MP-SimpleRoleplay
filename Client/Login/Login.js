"use strict";
API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "setLoginUiVisible":
            LoginUIOpen = args[0];
            if (args[0]) {
                API.setCanOpenChat(false);
                API.disableVehicleEnteringKeys(true);
                API.disableAlternativeMainMenuKey(true);
                cursorIndex = 0;
                API.callNative("0xA0EBB943C300E693", false);
                LoginCamera = API.createCamera(args[1], new Vector3(0, 0, 0));
                API.pointCameraAtPosition(LoginCamera, args[2]);
                API.setActiveCamera(LoginCamera);
            }
            else {
                API.fadeScreenOut(500);
                API.after(1000, "CloseLoginStep1");
                API.after(1200, "CLoseLoginStep2");
            }
            break;
    }
});
function CloseLoginStep1() {
    API.setCanOpenChat(true);
    API.disableVehicleEnteringKeys(false);
    API.disableAlternativeMainMenuKey(false);
    API.setActiveCamera(null);
    API.setHudVisible(true);
}
function CLoseLoginStep2() {
    API.fadeScreenIn(1000);
}
API.onUpdate.connect(function () {
    if (LoginUIOpen) {
        DrawLoginScreen();
        API.disableAllControlsThisFrame();
    }
});
var LoginUIOpen = false;
var password = "";
var LoginCamera = null;
var passwordPlaceholder = "Enter Password";
var res = API.getScreenResolutionMaintainRatio();
var safe = (res.Height / 4);
var posX = safe * 2.5;
var posY = res.Height / 2 - 200;
var Width = res.Width - (5 * safe);
var Height = 400;
var PasswordY = posY + 170;
var defaultTextBoxBg = new Vector3(241, 241, 241);
var highlightTextBoxBg = new Vector3(183, 255, 96);
var defaultButtonBg = new Vector3(55, 55, 55);
var highlightButtonBg = new Vector3(183, 255, 96);
var cursorIndex = 0;
function DrawLoginScreen() {
    API.drawRectangle(posX, posY, Width, Height, 30, 30, 30, 240);
    API.drawText("Login", posX + (Width / 2), posY + 20, 2, 255, 255, 255, 255, 1, 1, false, false, 500);
    API.drawText("Password", posX + 50, PasswordY, 0.7, 255, 255, 255, 255, 4, 0, false, false, 500);
    if (cursorIndex == 0) {
        API.drawRectangle(posX + 50, PasswordY + 50, Width - 100, 50, highlightTextBoxBg.X, highlightTextBoxBg.Y, highlightTextBoxBg.Z, 255);
    }
    else {
        API.drawRectangle(posX + 50, PasswordY + 50, Width - 100, 50, defaultTextBoxBg.X, defaultTextBoxBg.Y, defaultTextBoxBg.Z, 255);
    }
    if (password.length == 0) {
        API.drawText(passwordPlaceholder, posX + 60, PasswordY + 50, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
    }
    else {
        API.drawText(password.replace(/./g, "*"), posX + 60, PasswordY + 60, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
    }
    if (cursorIndex == 1) {
        API.drawRectangle(posX + 50, PasswordY + 130, Width - 100, 65, highlightButtonBg.X, highlightButtonBg.Y, highlightButtonBg.Z, 240);
        API.drawText("Login", posX + (Width / 2), PasswordY + 135, 0.7, 50, 50, 50, 255, 4, 1, false, false, 500);
    }
    else {
        API.drawRectangle(posX + 50, PasswordY + 130, Width - 100, 65, defaultButtonBg.X, defaultButtonBg.Y, defaultButtonBg.Z, 240);
        API.drawText("Login", posX + (Width / 2), PasswordY + 135, 0.7, 255, 255, 255, 255, 4, 1, false, false, 500);
    }
}
API.onKeyDown.connect(function (sender, e) {
    if (LoginUIOpen) {
        switch (e.KeyCode) {
            case Keys.Tab:
                switch (cursorIndex) {
                    case 0:
                        cursorIndex = 1;
                        break;
                    case 1:
                        cursorIndex = 0;
                        break;
                }
                break;
            case Keys.Up:
                if (cursorIndex == 0) {
                    cursorIndex = 1;
                }
                else {
                    cursorIndex--;
                }
                break;
            case Keys.Down:
                if (cursorIndex == 1) {
                    cursorIndex = 0;
                }
                else {
                    cursorIndex++;
                }
                break;
            case Keys.Enter:
                LoginButtonTriggered();
                break;
            case Keys.Back:
                switch (cursorIndex) {
                    case 0:
                        if (password.length != 0) {
                            password = password.substring(0, password.length - 1);
                        }
                        break;
                }
                break;
            default:
                switch (cursorIndex) {
                    case 0:
                        password += API.getCharFromKey(e.KeyValue, e.Shift, e.Control, e.Alt);
                        break;
                }
                break;
        }
    }
});
function LoginButtonTriggered() {
    API.triggerServerEvent("account_loginButtonPressed", password);
}
