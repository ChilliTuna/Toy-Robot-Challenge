namespace ToyRobotChallenge
{
    internal sealed class Simulation
    {
        public static Simulation instance 
        {
            get 
            { 
                if (instance == null) 
                { 
                    return new Simulation(); 
                } 
                else
                {
                    return instance;
                }
            }
            private set { } 
        }

        private bool shouldBeRunning = true;
        private ToyRobotController controller;

        private Simulation()
        {
            controller = new ToyRobotController();
        }

        public void Run()
        {
            Initialise();
            while (shouldBeRunning)
            {
                Update();
            }
        }

        public void Initialise()
        {
            Console.WriteLine("Welcome to the Toy Robot Challenge!");
            Console.WriteLine("Awaiting input...");
        }

        public void Update()
        {
            controller.HandleUserInput();
        }

        public void CloseSimulation()
        {
            shouldBeRunning = false;
        }
    }
}