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
                throw new ArgumentOutOfRangeException("dir", dir, "Enum value given has no name");
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
			//Converts X and Y to radians then uses the sine and cosine functions respectively to get the unit vector
			//Have had to include rounding as the floating point error is substantial (annoyingly, cos for 90deg is only close to 0)
			float x = (float)Math.Round(MathF.Sin(MathF.PI / 180 * (float)dir), 4);
			float y = (float)Math.Round(MathF.Cos(MathF.PI / 180 * (float)dir), 4);
            return new Vector2(x, y);
		}

        /// <summary>
        /// Gets a unit vector for a given Direction. Is faster than GetVector, but only works for main 4 cardinal directions
        /// </summary>
        /// <param name="dir">The Direction to get the unit vector for. Only works for North, South, East and West</param>
        /// <returns></returns>
        public static Vector2 GetVectorFast(this Direction dir)
		{
			if(dir == Direction.North)
			{
				return new Vector2(0, 1);
			}
			else if(dir == Direction.East)
			{
				return new Vector2(1, 0);
			}
			else if(dir == Direction.South)
			{
				return new Vector2(0, -1);
			}
			else if(dir == Direction.West)
			{
				return new Vector2(-1, 0);
			}
			else
			{
				throw new ArgumentOutOfRangeException("dir", dir, "Expected value of North, South, East or West");
			}
		}

		/// <summary>
		/// Modifies a given Direction by 90 degrees a given number of times
		/// </summary>
		/// <param name="dir">Direction to modify</param>
		/// <param name="amount">Number of times to add 90 degrees (accepts negatives)</param>
		/// <returns></returns>
		public static Direction ChangeBy (this Direction dir, int amount)
		{
			return (Direction)Tools.Mod(((amount * 90) + (int)dir), 360);
		}
    }
}