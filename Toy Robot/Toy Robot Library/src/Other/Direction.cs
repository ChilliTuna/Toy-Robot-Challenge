namespace ToyRobotLibrary
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
		/// <summary>
		/// Returns the name of the direction provided from the Direction enum
		/// </summary>
		/// <param name="dir">The Direction get the name for</param>
		/// <returns></returns>
		public static string GetCardinal (this Direction dir)
		{
			//This keeps providing a warning for something which probably will never occur, but I've decided to put some validation anyway
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

		/// <summary>
		/// Gets a unit vector for a given Direction
		/// </summary>
		/// <param name="dir">The Direction to get the unit vector for</param>
		/// <returns></returns>
		public static Vector2 GetVector(this Direction dir)
		{
			return new Vector2(MathF.Sin((float)dir), MathF.Cos((float)dir));
		}

		/// <summary>
		/// Modifies a given Direction by 90 degrees a given number of times
		/// </summary>
		/// <param name="dir">Direction to modify</param>
		/// <param name="amount">Number of times to add 90 degrees (accepts negatives)</param>
		/// <returns></returns>
		public static Direction ChangeBy (this Direction dir, int amount)
		{
			return (Direction)(((amount * 90) + (int)dir) % 360);
		}
    }
}