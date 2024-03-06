namespace Toy_Robot_Library
{
    /// <summary>
    /// Abstract class representing an entity on a board, which can be placed, rotated and moved
    /// </summary>
    public abstract class Actor
    {
        public Vector2 position { get; protected set; } = new Vector2();
        public Direction rotation { get; protected set; } = 0;
        public Board board { get; private set; } = new Board();
        protected bool isPlaced = false;

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

        protected ValidationMessage Rotate(Direction direction)
        {
            if (isPlaced)
            {
                return AttemptRotate(direction);
            }
            else
            {
                return new ValidationMessage(false, "Unsuccessful rotation. Must place on board first");
            }
            
        }

        public virtual ValidationMessage AttemptRotate(Direction direction)
        {
            rotation = (direction);

            return new ValidationMessage(true, "Successful rotation");
        }

        public ValidationMessage Move()
        {
            if (isPlaced)
            {
                return AttemptMove();
            }
            else
            {
                return new ValidationMessage(false, "Unsuccessful movement. Must place on board first");
            }
        }

        protected abstract ValidationMessage AttemptMove();
    }
}