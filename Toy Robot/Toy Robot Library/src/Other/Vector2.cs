namespace ToyRobotLibrary
{
    /// <summary>
    /// Struct containing an x y value pair as floats
    /// </summary>
    public struct Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2()
        { x = 0; y = 0; }

        public Vector2(float x, float y)
        { this.x = x; this.y = y; }

        //Operator overloads, for easy of use
        #region Overloads
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 vec, float amount)
        {
            return new Vector2(vec.x * amount, vec.y * amount);
        }

        public static Vector2 operator /(Vector2 vec, float amount)
        {
            return new Vector2(vec.x / amount, vec.y / amount);
        }
        #endregion

        /// <summary>
        /// If any components of the given vector are negative, sets them to positive
        /// </summary>
        /// <param name="vec">The Vector to make positive</param>
        /// <returns></returns>
        public static Vector2 Unsign(Vector2 vec)
        {
            if (vec.x < 0)
            {
                vec.x *= -1;
            }
            if (vec.y < 0)
            {
                vec.y *= -1;
            }
            return vec;
        }
    }
}