/// <reference path="../../../types-gt-mp/Definitions/index.d.ts" />

var isCuffed = false;
var player = null;
var lastRagdollAnimationChangeRequested = Math.abs(Date.now() - 3000);

API.onServerEventTrigger.connect(function (eventName, args) {
	player = API.getLocalPlayer();
	if (eventName == "Client_Cuffed") { isCuffed = args[0]; }
});

API.onUpdate.connect(function () {
	if (isCuffed) { CriminalIsCuffed(); }
});



function CriminalIsCuffed() {
	var vehicle = API.getPlayerVehicle(player);
	API.disableControlThisFrame(12); // WeaponWheelUpDown
	API.disableControlThisFrame(13); // WeaponWheelLeftRight
	API.disableControlThisFrame(14); // WeaponWheelNext
	API.disableControlThisFrame(15); // WeaponWheelPrev
	API.disableControlThisFrame(16); // SelectNextWeapon
	API.disableControlThisFrame(17); // SelectPrevWeapon
	API.disableControlThisFrame(24); // Attack
	API.disableControlThisFrame(25); // Aim
	API.disableControlThisFrame(47); // Detonate
	API.disableControlThisFrame(58); // ThrowGrenade
	API.disableControlThisFrame(59); // VehicleMoveLeftRight
	API.disableControlThisFrame(63); // VehicleMoveLeftOnly
	API.disableControlThisFrame(66); // VehicleGunLeftRight
	API.disableControlThisFrame(68); // VehicleAim
	API.disableControlThisFrame(69); // VehicleAttack
	API.disableControlThisFrame(70); // VehicleAttack2
	API.disableControlThisFrame(86); // VehicleHorn
	API.disableControlThisFrame(89); // VehicleFlyYawLeft
	API.disableControlThisFrame(90); // VehicleFlyYawRight
	API.disableControlThisFrame(91); // VehiclePassengerAim
	API.disableControlThisFrame(92); // VehiclePassengerAttack
	API.disableControlThisFrame(107); // VehicleFlyRollLeftRight
	API.disableControlThisFrame(108); // VehicleFlyRollLeftOnly
	API.disableControlThisFrame(109); // VehicleFlyRollRightOnly
	API.disableControlThisFrame(110); // VehicleFlyPitchUpDown
	API.disableControlThisFrame(111); // VehicleFlyPitchUpOnly
	API.disableControlThisFrame(112); // VehicleFlyPitchDownOnly
	API.disableControlThisFrame(114); // VehicleFlyAttack
	API.disableControlThisFrame(140); // MeleeAttackLight
	API.disableControlThisFrame(141); // MeleeAttackHeavy
	API.disableControlThisFrame(142); // MeleeAttackAlternate
	API.disableControlThisFrame(257); // Attack2
	API.disableControlThisFrame(263); // MeleeAttack1
	API.disableControlThisFrame(264); // MeleeAttack2
	API.disableControlThisFrame(331); // VehicleFlyAttack2

	if (!API.isPlayerRagdoll(player) && (API.getAnimCurrentTime(player, "mp_arresting", "idle") == -1 || API.getAnimCurrentTime(player, "mp_arresting", "idle") == 0.00000000)
		&& Math.abs(Date.now() - lastRagdollAnimationChangeRequested) > 3000) {
		lastRagdollAnimationChangeRequested = Date.now();
		API.triggerServerEvent("Police_ApplyCuffedAnimation");
	}


	// If player sits cuffed in a police vehicle (and not the driver) -> Can't get out
	if (API.isPlayerInAnyVehicle(player) && API.getPlayerVehicleSeat(player) != -1) {
		if (CriminalisPoliceVehicle(vehicle)) {
			API.disableControlThisFrame(75); // VehicleExit
		}
	}

	function CriminalisPoliceVehicle(vehicle) {
		var model = API.getEntityModel(vehicle);

		switch (model) {
			case 2046537925: // Police
			case -1627000575: // Police 2
			case 1912215274: // Police 3
			case -1973172295: // Police 4
			case 456714581: // PoliceT
			case -1683328900: // Sheriff
			case 1922257928: // Sheriff2
			case -34623805: // Police Bike
			case 353883353: // Police Maverick
				return true;
			default:
				return false;
		}
	}

}