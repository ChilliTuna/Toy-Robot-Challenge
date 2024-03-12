using ToyRobotLibrary;

namespace ToyRobotChallenge
{
    internal class ToyRobotController
    {
        public ToyRobot robot { get; private set; }

        public bool writeSuccessMessages = false;

        public ToyRobotController()
        {
            robot = new ToyRobot();
        }

        public ToyRobotController(ToyRobot robot)
        {
            this.robot = robot;
        }

        public void SetRobot(ToyRobot robot)
        {
            this.robot = robot;
        }

        public void HandleUserInput()
        {
            string? input = Console.ReadLine();
            if (Commands.ValidateString(input))
            {
                CommandInstance? command = Commands.GetCommandInstance(input);
                if (command != null)
                {
                    PerformRobotAction(command);
                }
                else
                {
                    Console.WriteLine("Command invalid. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Input invalid. Please try again.");
            }
        }

        public void PerformRobotAction(CommandInstance command)
        {
            ValidationMessage? result = null;
            if (command.command == Command.Place)
            {
                if (command.ValidateParameters())
                {
                    if (command.parameters != null)
                    {
                        Vector2 position = new Vector2(int.Parse(command.parameters[0]), int.Parse(command.parameters[1]));
                        Direction dir = Enum.Parse<Direction>(command.parameters[2]);
                        result = robot.Place(position, dir);
                    }
                }
            }
            else if (command.command == Command.Move)
            {
                result = robot.Move();
            }
            else if (command.command == Command.Left)
            {
                result = robot.TurnLeft();
            }
            else if (command.command == Command.Right)
            {
                result = robot.TurnRight();
            }
            else if (command.command == Command.Report)
            {
                if (robot.isPlaced)
                {
                    Console.WriteLine(robot.position.x + "," + robot.position.y + "," + robot.rotation.GetCardinal());
                }
                else
                {
                    Console.WriteLine("Robot not yet placed. Please PLACE robot before using other commands");
                }
            }
            else
            {
                throw new ArgumentException("Invalid command used", "command");
            }
            if (result != null)
            {
                ValidationMessage finalResult = (ValidationMessage)result;
                if (finalResult.success == false || writeSuccessMessages == true)
                {
                    Console.WriteLine(finalResult.message);
                }
            }
        }

        public void RunTest()
        {
            robot.Place();
            Console.WriteLine(robot.position.x + ", " + robot.position.y + ", " + robot.rotation.GetCardinal());
            robot.TurnLeft();
            Console.WriteLine(robot.Move().message);
            Console.WriteLine(robot.position.x + ", " + robot.position.y + ", " + robot.rotation.GetCardinal());
        }
    }
}