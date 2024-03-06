namespace Toy_Robot_Library
{
    /// <summary>
    /// The board with which actors exist on
    /// </summary>
    public struct Board
    {
        private Vector2 origin;
        private Vector2 dimensions;

        public Board()
        {
            origin = new Vector2();
            dimensions = new Vector2(5, 5);
        }

        public Board(Vector2 origin, Vector2 dimensions)
        {
            this.origin = origin;
            this.dimensions = dimensions;
        }

        internal bool IsPointOnBoard(Vector2 pos)
        {
            return 
                (origin.x <= pos.x && pos.x < origin.x + dimensions.x) &
                (origin.y <= pos.y && pos.y < origin.y + dimensions.y);
        }
    }
}
