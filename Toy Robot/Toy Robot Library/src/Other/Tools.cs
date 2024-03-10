namespace ToyRobotLibrary
{
    public static class Tools
    {
        /// <summary>
        /// C#'s implementation of % is not actually a modulo, but a remainder.
        /// This provides actual modulo functionality
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>First value modulo second value </returns>
        public static float Mod(float a, float b)
        {
            float c = a % b;
            return c<0 ? c + b : c;
        }
    }
}
