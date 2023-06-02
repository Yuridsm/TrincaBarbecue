using System.CommandLine;

namespace TrincaBarbecue.CLI.CommandLine
{
    public class TrincaCommand
    {
        private Command _command = new Command("trinca", "Trinca CLI");

        public void SetCommand(Command command)
        {
            _command.AddCommand(command);
        }

        public Command Build()
        {
            return _command;
        }
    }
}
