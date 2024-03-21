namespace ToyRobotChallenge
{
    /// <summary>
    /// Combination of a Command and the paramaters given to it
    /// </summary>
    public class CommandInstance
    {
        public Command? command { get; set; }
        public string[]? parameters { get; set; }
    }
}
