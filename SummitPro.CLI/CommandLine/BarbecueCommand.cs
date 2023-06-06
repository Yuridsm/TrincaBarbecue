using System.CommandLine;

namespace SummitPro.CLI.CommandLine
{
    public class BarbecueCommand
    {
        private Command _command = new Command("barbecue", "Barbecue Resouce Management");

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
