namespace Toy_Robot_Library
{
    /// <summary>
    /// Struct containing an x y value pair as floats
    /// </summary>
    public struct Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2() { x = 0; y = 0; }
        public Vector2(float x, float y) { this.x = x; this.y = y; }
    }
}