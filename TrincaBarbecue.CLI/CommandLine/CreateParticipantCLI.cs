using System.CommandLine;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Infrastructure.DistributedCache;

namespace TrincaBarbecue.CLI.CommandLine
{
    public class CreateParticipantCLI
    {
        private Command _command = new Command("create", "Create a new participand");

        private readonly Option<string> _name = new Option<string>("--name", "Add name to participant");
        private readonly Option<string> _contribution = new Option<string>("--contribution", "Participant contribution value");
        private readonly Option<string> _bringDrink = new Option<string>("--bring-drink", "Whether participant will come drinks, so mark with true, otherwise, false");
        private readonly Option<string> _username = new Option<string>("--username", "Participant username: Ex.: yuridsm");
        private readonly Option<string> _addItems = new Option<string>("--add-items", "Add participant's item suck as 'item 01;item 02, item 03'. Use semicolon for separating items");

        public void SetOption(Option option)
        {
            _command.AddOption(option);
        }

        public Command Build()
        {
            SetOption(_name);
            SetOption(_contribution);
            SetOption(_bringDrink);
            SetOption(_username);
            SetOption(_addItems);

            _command.SetHandler((name, contribution, bringDrink, username, addItems) =>
            {
                createParticipantHandler(name, contribution, bringDrink, username, addItems);
            }, _name, _contribution, _bringDrink, _username, _addItems);
            return _command;
        }
        private void createParticipantHandler(string name, string contribution, string bringDrink, string username, string addItems)
        {

            var input = CreateInputBoundary.FactoryMethod
                (description = description,
                new List<string> { remark },
                DateTime.Parse(begin),
            DateTime.Parse(end));

            _createBarbecueController
                .SetDistributedCache(new CachedRepository());

            var output = _createBarbecueController.Handle(input);
        }
    }
}
