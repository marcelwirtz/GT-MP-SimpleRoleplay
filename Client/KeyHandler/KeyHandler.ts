/// <reference path="../../types-gt-mp/Definitions/index.d.ts" />
API.onKeyDown.connect(function (sender, e) {
	switch (e.KeyCode) {
		case Keys.E:
			API.triggerServerEvent("KeyboardKey_E_Pressed");
			break;
		case Keys.K:
			API.triggerServerEvent("KeyboardKey_K_Pressed");
			break;
		case Keys.M:
			API.triggerServerEvent("KeyboardKey_M_Pressed");
			break;
		case Keys.U:
			API.triggerServerEvent("KeyboardKey_U_Pressed");
			break;
		case Keys.Z:
			API.triggerServerEvent("KeyboardKey_Z_Pressed");
			break;
	}
});