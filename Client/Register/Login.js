"use strict";
API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "setLoginUiVisible":
            LoginUIOpen = args[0];
            if (args[0]) {
                API.setCanOpenChat(false);
                cursorIndex = 0;
            }
            else {
                API.setCanOpenChat(true);
            }
            break;
    }
});
API.onUpdate.connect(function () {
    if (LoginUIOpen) {
        DrawLoginScreen();
        API.disableAllControlsThisFrame();
        API.disableVehicleEnteringKeys(true);
        API.disableAlternativeMainMenuKey(true);
    }
});
var LoginUIOpen = false;
var username = "";
var password = "";
var usernamePlaceholder = "Enter Username";
var passwordPlaceholder = "Enter Password";
var res = API.getScreenResolutionMaintainRatio();
var safe = (res.Height / 4);
var posX = safe * 2.5;
var posY = safe;
var Width = res.Width - (5 * safe);
var Height = 2 * safe;
var UsernameY = posY + 170;
var PasswordY = posY + 290;
var defaultTextBoxBg = new Vector3(241, 241, 241);
var highlightTextBoxBg = new Vector3(183, 255, 96);
var defaultButtonBg = new Vector3(55, 55, 55);
var highlightButtonBg = new Vector3(122, 122, 122);
var cursorIndex = 0;
function DrawLoginScreen() {
    API.drawRectangle(posX, posY, Width, Height, 30, 30, 30, 240);
    API.drawText("Login", posX + (Width / 2), posY + 20, 2, 255, 255, 255, 255, 1, 1, false, false, 500);
    API.drawText("Username", posX + 50, UsernameY, 0.7, 255, 255, 255, 255, 4, 0, false, false, 500);
    if (cursorIndex == 0) {
        API.drawRectangle(posX + 50, UsernameY + 50, Width - 100, 50, highlightTextBoxBg.X, highlightTextBoxBg.Y, highlightTextBoxBg.Z, 255);
    }
    else {
        API.drawRectangle(posX + 50, UsernameY + 50, Width - 100, 50, defaultTextBoxBg.X, defaultTextBoxBg.Y, defaultTextBoxBg.Z, 255);
    }
    if (username.length == 0) {
        API.drawText(usernamePlaceholder, posX + 60, UsernameY + 50, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
    }
    else {
        API.drawText(username, posX + 60, UsernameY + 50, 0.7, 50, 50, 50, 255, 4, 0, false, false, Width - 120);
    }
    API.drawText("Password", posX + 50, PasswordY, 0.7, 255, 255, 255, 255, 4, 0, false, false, 500);
    if (cursorIndex == 1) {
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
    if (cursorIndex == 2) {
        API.drawRectangle(posX + 50, PasswordY + 130, Width - 100, 65, highlightButtonBg.X, highlightButtonBg.Y, highlightButtonBg.Z, 240);
    }
    else {
        API.drawRectangle(posX + 50, PasswordY + 130, Width - 100, 65, defaultButtonBg.X, defaultButtonBg.Y, defaultButtonBg.Z, 240);
    }
    API.drawText("Login", posX + (Width / 2), PasswordY + 135, 0.7, 255, 255, 255, 255, 4, 1, false, false, 500);
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
                }
                else {
                    cursorIndex--;
                }
                break;
            case Keys.Down:
                if (cursorIndex == 2) {
                    cursorIndex = 0;
                }
                else {
                    cursorIndex++;
                }
                break;
            case Keys.Enter:
                if (cursorIndex == 2) {
                    LoginButtonTriggered();
                }
                break;
            case Keys.Back:
                switch (cursorIndex) {
                    case 0:
                        if (username.length != 0) {
                            username = username.substring(0, username.length - 1);
                        }
                        break;
                    case 1:
                        if (password.length != 0) {
                            password = password.substring(0, password.length - 1);
                        }
                        break;
                }
                break;
            default:
                switch (cursorIndex) {
                    case 0:
                        username += API.getCharFromKey(e.KeyValue, e.Shift, e.Control, e.Alt);
                        break;
                    case 1:
                        password += API.getCharFromKey(e.KeyValue, e.Shift, e.Control, e.Alt);
                        break;
                }
                break;
        }
    }
});
function LoginButtonTriggered() {
    LoginUIOpen = false;
    API.setCanOpenChat(true);
    API.sendNotification("Login Button Pressed~n~Username: ~y~" + username + "~w~~n~Password: ~y~" + password);
}
