using GrandTheftMultiplayer.Shared.Math;

namespace SimpleRoleplay.Server.Model
{
	class GarageSpawn
	{
		public Vector3 Position { get; set; }
		public Vector3 Rotation { get; set; }
		public GarageSpawn()
		{
			Position = new Vector3();
			Rotation = new Vector3();
		}
	}
}
