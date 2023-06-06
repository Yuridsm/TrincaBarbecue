using System.CommandLine;

namespace SummitPro.CLI.CommandLine
{
    public class ParticipantCommand
    {
        private Command _command = new Command("participant", "Participant Resouce Management");

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
