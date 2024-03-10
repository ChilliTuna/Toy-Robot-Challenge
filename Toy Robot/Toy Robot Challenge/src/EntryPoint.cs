using ToyRobotLibrary;
using System;

public class EntryPoint
{
    public static void Main()
    {
        ToyRobot robot = new ToyRobot();
        robot.Place();
        Console.WriteLine(robot.position.x + ", " + robot.position.y + ", " + robot.rotation.GetCardinal());
        robot.TurnLeft();
        Console.WriteLine(robot.Move().message);
        Console.WriteLine(robot.position.x + ", " + robot.position.y + ", " + robot.rotation.GetCardinal());
    }
}