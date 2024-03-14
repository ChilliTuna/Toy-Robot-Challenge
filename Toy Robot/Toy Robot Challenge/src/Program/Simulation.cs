namespace ToyRobotChallenge
{
    internal sealed class Simulation
    {
        private static Simulation instance;

        public static Simulation Instance
        {
            get 
            { 
                if (instance == null) 
                {
                    instance = new Simulation();
                }
                return instance;
            }
            private set { } 
        }

        private bool shouldBeRunning = true;
        private ToyRobotController controller;
        private bool testMode = false;

        private Simulation()
        {
            controller = new ToyRobotController();
            instance = this;
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
            if (testMode)
            {
                controller.RunStandardTest();
            }
            Console.WriteLine("Awaiting input...");
        }

        public void Update()
        {
            if (testMode)
            {
                return;
            }
            controller.HandleUserInput();
        }

        public void CloseSimulation()
        {
            shouldBeRunning = false;
        }
    }
}