namespace SimpleRoleplay.Server.Services.CharacterService
{
	public enum Gender
	{
		Male = 0,
		Female = 1
	}

	public enum CharacterComponents
	{
		Face = 0,
		Mask = 1,
		Hair = 2,
		Torso = 3,
		Leg = 4,
		Backpack = 5,
		Feet = 6,
		Accessories = 7,
		Undershirt = 8,
		BodyArmor = 9,
		Decal = 10,
		Top = 11
	}

	public enum CharacterProps
	{
		Hat = 0,
		Glasses = 1,
		Ear = 2,
		Watch = 3,
		Bracelets = 4
	}

	public enum CharacterHeadOverlay // http://www.dev-c.com/nativedb/func/info/48f44967fa05cc1e
	{
		Blemish = 0,
		FacialHair = 1,
		Eyebrows = 2,
		Ageing = 3,
		Makeup = 4,
		Blush = 5,
		Complexion = 6,
		SunDamage = 7,
		Lipstick = 8,
		Freckles = 9,
		ChestHair = 10,
		BodyBlemishes = 11,
		AddBodyBlemishes = 12
	}

	public enum CharacterHeadOverlayColorType // http://www.dev-c.com/nativedb/func/info/497bf74a7b9cb952
	{
		Unkown = 0,
		EyebrowsFacialHairChestHair = 1,
		BlushLipstick = 2
	}
}
