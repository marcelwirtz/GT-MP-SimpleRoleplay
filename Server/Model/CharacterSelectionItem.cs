namespace SimpleRoleplay.Server.Model
{
	public class CharacterSelectionItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public CharacterSelectionItem(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
