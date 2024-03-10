namespace ToyRobotLibrary
{
    /// <summary>
    /// Abstract class representing an entity on a board, which can be placed, rotated and moved
    /// </summary>
    public abstract class Actor
    {
        #region Variables
        /// <summary>
        /// The position of the actor as a Vector2, denoting its x and y coordinates
        /// </summary>
        public Vector2 position { get; protected set; } = new Vector2();
        /// <summary>
        /// The direction the actor is facing
        /// </summary>
        public Direction rotation { get; protected set; } = 0;
        /// <summary>
        /// The board the actor exists on
        /// </summary>
        public Board board { get; private set; } = new Board();
        /// <summary>
        /// Whether the actor is currently placed on the board (true), or not (false)
        /// </summary>
        protected bool isPlaced = false;
        #endregion

        #region Functions
        /// <summary>
        /// Places the actor on a board at a given position
        /// </summary>
        /// <param name="startPosition">The position to place the actor on the board</param>
        /// <returns></returns>
        public ValidationMessage Place(Vector2 startPosition)
        {
            //If the point is on the board, set the positon to position the parameter
            if (board.IsPointOnBoard(startPosition))
            {
                this.position = startPosition;
                isPlaced = true;
                return new ValidationMessage(true, "Successful placement");
            }
            else
            {
                return new ValidationMessage(false, "Unsuccessful placement. Entered point not on board");
            }
        }

        /// <summary>
        /// Places the actor on a board at 0, 0
        /// </summary>
        /// <returns></returns>
        public ValidationMessage Place()
        {
            return Place(new Vector2(0, 0));
        }

        /// <summary>
        /// Places the actor on a given board at a given position
        /// </summary>
        /// <param name="startPosition">The position to place the actor on the board</param>
        /// <param name="newBoard">The board to place the actor on</param>
        /// <returns></returns>
        public ValidationMessage Place(Vector2 startPosition, Board newBoard)
        {
            //If the point is on the new board, set the board to the board parameter and set the positon to position the parameter
            if (newBoard.IsPointOnBoard(startPosition))
            {
                this.board = newBoard;
                this.position = startPosition;
                isPlaced = true;
                return new ValidationMessage(true, "Successful placement");
            }
            else
            {
                return new ValidationMessage(false, "Unsuccessful placement. Entered point not on board");
            }
        }

        /// <summary>
        /// Sets the actor's rotation to a given Direction
        /// </summary>
        /// <param name="direction">The Direction to set the actor's rotation to</param>
        /// <returns></returns>
        public ValidationMessage Rotate(Direction direction)
        {
            if (isPlaced)
            {
                return PerformRotate(direction);
            }
            else
            {
                return new ValidationMessage(false, "Unsuccessful rotation. Must place on board first");
            }
            
        }

        /// <summary>
        /// Does that actual rotation functionality. Is called by the Rotate function
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        protected virtual ValidationMessage PerformRotate(Direction direction)
        {
            rotation = direction;

            return new ValidationMessage(true, "Successful rotation");
        }

        /// <summary>
        /// Moves the actor
        /// </summary>
        /// <returns></returns>
        public ValidationMessage Move()
        {
            if (isPlaced)
            {
                return PerformMove();
            }
            else
            {
                return new ValidationMessage(false, "Unsuccessful movement. Must place on board first");
            }
        }

        /// <summary>
        /// Does the actual move functionality. Is called by the Move function
        /// </summary>
        /// <returns></returns>
        protected abstract ValidationMessage PerformMove();
        #endregion
    }
}