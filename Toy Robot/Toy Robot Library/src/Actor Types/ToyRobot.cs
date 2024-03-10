namespace ToyRobotLibrary
{
    public class ToyRobot : Actor
    {
        /// <summary>
        /// The amount the Toy Robot moves in a given action
        /// </summary>
        public int moveSpeed { get; internal set; } = 1;

        #region Functions
        /// <summary>
        /// Moves the toy robot forward (defined by its direction) by its moveSpeed if it meets the requirements
        /// </summary>
        /// <returns></returns>
        protected override ValidationMessage PerformMove()
        {
            Vector2 moveVec = position + (rotation.GetVector() * moveSpeed);
            if (board.IsPointOnBoard(moveVec))
            {
                position = moveVec;
                return new ValidationMessage(true, "Successful movement");
            }
            else
            {
                return new ValidationMessage(false, "Unsuccessful movement. Tried to move off of board");
            }
        }

        /// <summary>
        /// Rotates the toy robot by 90 degrees to the left
        /// </summary>
        /// <returns></returns>
        public ValidationMessage TurnLeft()
        {
            return Rotate((Direction)rotation.ChangeBy(-1));
        }
        
        /// <summary>
        /// Rotates the toy robot by 90 degrees the the right
        /// </summary>
        /// <returns></returns>
        public ValidationMessage TurnRight()
        {
            return Rotate((Direction)rotation.ChangeBy(1));
        }
        #endregion
    }
}
