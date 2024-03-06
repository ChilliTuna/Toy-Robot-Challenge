namespace Toy_Robot_Library
{
	/// <summary>
	/// Enum representing possible directions as cardinal directions and their respective angle from north in degrees
	/// </summary>
	public enum Direction
	{
		North = 0,
		East = 90,
		South = 180,
		West = 270
	}

	/// <summary>
	/// Extension function to return an instance of Direction as the name of its cardinal direction
	/// </summary>
	public static class DirectionExtensions
	{
		public static string GetCardinal (this Direction dir)
		{
			string name = Enum.GetName(typeof(Direction), dir);
			if(name == null)
			{
				return "Invalid Direction: " + dir;
			}
			else
			{
				return name;
			}
		}

		public static Vector2 GetVector(this Direction dir)
		{
			return new Vector2(); //build logic for this to work
		}

		public static int ChangeBy (this Direction dir, int amount)
		{
			return (int)dir + amount; //build logic for this to work
		}
    }
}
