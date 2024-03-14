using System.Text.RegularExpressions;
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
        private static Command? TextToCommand(string text)
        {
            if (text == null)
            {
                return null;
            }
            else
            {
                Command outObj;
                if (Enum.TryParse<Command>(text, true, out outObj))
                {
                    return outObj;
                }
                else
                {
                    return null;
                }
            }
        }

        internal static CommandInstance? GetCommandInstance(string? text)
        {
            if (ValidateString(text) && text != null)
            {
                CommandInstance? commandInstance = new CommandInstance();
                string[] components = text.Split(' ', 2);
                commandInstance.command = TextToCommand(components[0]);
                if (components.Length > 1)
                {
                    components[1] = Regex.Replace(components[1], @"(\s+)", "");
                    commandInstance.parameters = components[1].Split(',');
                }
                else
                {
                    commandInstance.parameters = null;
                }
                return commandInstance;
            }
            else
            {
                return null;
            }
        }

        internal static string? GetCommandText(string? text)
        {
            if (ValidateString(text) && text != null)
            {
                string[] components = text.Split(' ', 2);
                return components[0];
            }
            else
            {
                return null;
            }
        }

        public static bool ValidateString(string? text)
        {
            if (text == null)
            {
                return false;
            }
            else
            {
                return !Regex.IsMatch(text, @"([^a-zA-Z, \d])");
            }
        }

        internal static bool ValidateParameters(this CommandInstance command)
        {
            bool isValid = true;
            if (command.command == null)
            {
                isValid = true;
            }
            else if (command.command == Command.Place)
            {
                if (command.parameters == null || command.parameters.Length < 3)
                {
                    isValid = false;
                }
                else
                {
                    int param1Out;
                    bool param1 = int.TryParse(command.parameters[0], out param1Out);
                    int param2Out;
                    bool param2 = int.TryParse(command.parameters[1], out param2Out);
                    Direction param3Out;
                    bool param3 = Enum.TryParse<Direction>(command.parameters[2], true, out param3Out);
                    isValid = param1 && param2 && param3;
                }
                if (!isValid)
                {
                    Console.WriteLine("Invalid parameters. Place command expects: x (number), y (number), Direction (text)");
                }
            }
            return isValid;
        }
    }
}