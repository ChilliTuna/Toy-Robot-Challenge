namespace Toy_Robot_Library
{
    public class ToyRobot : Actor
    {
        protected override ValidationMessage AttemptMove()
        {
            //Need to build logic to make this work
            return new ValidationMessage(true, "It worked");
        }

        public ValidationMessage TurnLeft()
        {
            return Rotate((Direction)rotation.ChangeBy(-90));
        }
        
        public ValidationMessage TurnRight()
        {
            return Rotate((Direction)rotation.ChangeBy(+90));
        }
    }
}
