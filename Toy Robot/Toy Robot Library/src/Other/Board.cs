namespace ToyRobotLibrary
{
    /// <summary>
    /// The board with which actors exist on
    /// </summary>
    public struct Board
    {
        /// <summary>
        /// The origin point of the board. Is considered the south-west corner of the board
        /// </summary>
        private Vector2 origin;
        /// <summary>
        /// The dimensions that the board extends from the origin
        /// </summary>
        private Vector2 dimensions;

        /// <summary>
        /// Generates the default board
        /// </summary>
        public Board()
        {
            origin = new Vector2();
            dimensions = new Vector2(5, 5);
        }

        /// <summary>
        /// Generates a board with given parameters
        /// </summary>
        /// <param name="origin">The origin of the board</param>
        /// <param name="dimensions">The dimensions of the board, from the origin. Negative values will be made positive</param>
        public Board(Vector2 origin, Vector2 dimensions)
        {
            this.origin = origin;
            this.dimensions = Vector2.Abs(dimensions);
        }

        /// <summary>
        /// Checks if a given point exists within the boards of the board
        /// </summary>
        /// <param name="pos">The position being checked</param>
        /// <returns></returns>
        internal bool IsPointOnBoard(Vector2 pos)
        {
            return 
                (origin.x <= pos.x && pos.x < origin.x + dimensions.x) &
                (origin.y <= pos.y && pos.y < origin.y + dimensions.y);
        }
    }
}
