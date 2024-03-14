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

        public void HandleInput(string? input)
        {
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

        public void HandleUserInput()
        {
            string? input = Console.ReadLine();
            HandleInput(input);
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
                        Direction dir = Enum.Parse<Direction>(command.parameters[2], true);
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
            else if (command.command == null)
            {
                Console.WriteLine("Invalid command. Please use accepted command");
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

        public void RunStandardTest(bool shouldWriteSuccess = true)
        {
            //Running standard test will output the success messages by default
            bool previousSuccessMessages = writeSuccessMessages;
            writeSuccessMessages = shouldWriteSuccess;

            //      ||Write tests to conduct here||
            string[] tests = 
            { 
                "MOVE",
                "LEFT",
                "RIGHT",
                "REPORT",
                "PLACE 5, 5, NORTH",
                "PLACE 6, 0, NORTH",
                "PLACE 3, 5, NORTH",
                "PLACE -1, 2, NORTH",
                "PLACE 4, -4, NORTH",
                "PLACE 3, 2, INVALIDWORD",
                "INVALIDWORD 9, TEST",
                "PLACE 2, 4, NORTH",
                "REPORT",
                "PLACE 1, 0, EAST",
                "PLACE 7, 1, NORTH",
                "REPORT",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT",
                "RIGHT",
                "MOVE",
                "REPORT",
                "PLACE 0, 0, WEST",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT",
                "PLACE 4, 4, NORTH",
                "MOVE",
                "RIGHT",
                "MOVE",
                "REPORT",
                "LEFT",
                "LEFT",
                "MOVE",
                "LEFT",
                "MOVE",
                "REPORT",
                "RIGHT",
                "RIGHT",
                "RIGHT",
                "REPORT",
                "RIGHT",
                "REPORT",
                "LEFT",
                "REPORT"
            };

            foreach (string test in tests)
            {
                Console.WriteLine(test);
                HandleInput(test);
                Console.WriteLine();
            }

            writeSuccessMessages = previousSuccessMessages;
        }
    }
}