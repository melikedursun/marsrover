using System.Collections.Generic;
using MarsRover.Command;

namespace MarsRover.Helper
{
    public class CommandHelper
    {
        private readonly string _command;
        private static readonly Dictionary<string, ICommand> CommandDictionaries = new Dictionary<string, ICommand>()
        {
            { "M", new MoveCommand() },
            { "L", new LeftCommand() },
            { "R", new RightCommand() }
        };

        public CommandHelper(string command)
        {
            _command = command.ToUpper();
        }

        public List<ICommand> CreateCommand()
        {
            List<ICommand> commands = new List<ICommand>();
            var splitCommand = SplitCommand();

            foreach (var c in splitCommand)
            {
                ICommand command = CommandDictionaries[c.ToString()];
                commands.Add(command);
            }

            return commands;
        }

        public char[] SplitCommand()
        {
            if (!string.IsNullOrEmpty(_command))
            {
                return _command.ToCharArray();
            }
            return new char[0];
        }
    }
}