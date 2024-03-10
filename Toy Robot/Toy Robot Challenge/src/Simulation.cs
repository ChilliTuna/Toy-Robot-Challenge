using ToyRobotLibrary;

namespace ToyRobotChallenge
{
    public class Simulation
    {
        bool shouldBeRunning = true;

        ToyRobot robot = new ToyRobot();

        public void Run()
        {
            Initialise();
            Update();
        }

        public void Initialise()
        {
            Console.WriteLine("Welcome to the Toy Robot Challenge!");
            Console.WriteLine("Awaiting input...");
        }

        public void Update()
        {
            while (shouldBeRunning)
            {
                string? input = Console.ReadLine();
                Console.WriteLine(input);
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
