namespace SimpleRoleplay.Server.Services.FactionService
{
	public enum FactionType
	{
		Citizen = 0,
		Police = 1,
		EMS = 2,
		State = 3
	}

	public enum AnimationFlags
	{
		Loop = 1 << 0,
		StopOnLastFrame = 1 << 1,
		OnlyAnimateUpperBody = 1 << 4,
		AllowPlayerControl = 1 << 5,
		Cancellable = 1 << 7
	}
}
