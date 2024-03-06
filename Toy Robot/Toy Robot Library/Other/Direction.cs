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
		public static string Cardinal (this Direction dir)
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
    }
}
