using GrandTheftMultiplayer.Shared.Math;

namespace SimpleRoleplay.Server.Model
{
	public class SpawnPosition
	{
		public string Name { get; set; }
		public Vector3 Position { get; set; }
		public Vector3 Rotation { get; set; }
		public SpawnPosition(string name, Vector3 position, Vector3 rotation)
		{
			Position = position;
			Rotation = rotation;
			Name = name;
		}
	}
}
