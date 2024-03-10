using ToyRobotLibrary;

namespace ToyRobotChallenge
{
    public enum Command
    {
        Place,
        Move,
        Left,
        Right,
        Report
    }

    public static class Commands
    {
        public static void PerformRobotAction(this ToyRobot robot, Command command)
        {
            ValidationMessage result = new ValidationMessage();
            if (command == Command.Place)
            {
                result = robot.Place();
            }
            else if (command == Command.Move)
            {
                result = robot.Move();
            }
            else if (command == Command.Left)
            {
                result = robot.TurnLeft();
            }
            else if (command == Command.Right)
            {
                result = robot.TurnRight();
            }
            else if (command == Command.Report)
            {
                //Do report
            }
            else
            {
                throw new ArgumentException("Invalid command used", "command");
            }
            if (result.success == false)
            {
                Console.WriteLine(result.message);
            }
        }

        public static void TextToCommand(string text)
        {
            //Do conversion of string to command here
            //Need to build a parsing function that parses the text input by the user
        }
    }
}
