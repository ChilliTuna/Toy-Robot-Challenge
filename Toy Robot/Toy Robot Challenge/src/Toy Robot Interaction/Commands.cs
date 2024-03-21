using System.Text.RegularExpressions;
using ToyRobotLibrary;

namespace ToyRobotChallenge
{
    /// <summary>
    /// Enum of possible commands
    /// </summary>
    public enum Command
    {
        Place,
        Move,
        Left,
        Right,
        Report
    }

    /// <summary>
    /// Class for utilising and interpreting Commands
    /// </summary>
    public static class Commands
    {
        /// <summary>
        /// Converts given string to a Command
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a Command Instance from a given string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets just the Command for a given string, as a string (the name of the command, ie: "Place")
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Runs validation on a given string, to ensure it meets the expected input format (only includes alphanum, spaces, commas and hyphens)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ValidateString(string? text)
        {
            if (text == null)
            {
                return false;
            }
            else
            {
                return !Regex.IsMatch(text, @"([^a-zA-Z, \-\d])");
            }
        }

        /// <summary>
        /// Runs validation on the parameters for a given Command Instance, to ensure the parameters given match the Command provided
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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