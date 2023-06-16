//using SummitPro.Application.UseCase.AddParticipante;
//using SummitPro.Infrastructure.Http.Controller;
//using System.CommandLine;
//using SummitPro.Application.UseCase.BindParticipant;
//using SummitPro.Infrastructure.DistributedCache;

//namespace SummitPro.CLI.CommandLine
//{
//    public class CreateParticipantCLI
//    {
//        private Command _command = new Command("create", "Create a new participand");

//        private readonly Option<string> _bind = new Option<string>("--bind", "Bind a Participant to one Barbecue");
//        private readonly Option<string> _name = new Option<string>("--name", "Add name to participant");
//        private readonly Option<string> _contribution = new Option<string>("--contribution", "Participant contribution value");
//        private readonly Option<bool> _bringDrink = new Option<bool>("--bring-drink", "Whether participant will come drinks, so mark with true, otherwise, false");
//        private readonly Option<string> _username = new Option<string>("--username", "Participant username: Ex.: yuridsm");
//        private readonly Option<string> _addItems = new Option<string>("--add-items", "Add participant's item suck as 'item 01;item 02, item 03'. Use semicolon for separating items");

//        private AddParticipantController _addParticipantController;
//        private BindParticipantTobarbecueController _bindParticipantController;

//        public CreateParticipantCLI(
//            AddParticipantController addParticipantController,
//            BindParticipantTobarbecueController bindParticipantController
//            )
//        {
//            _addParticipantController = addParticipantController;
//            _bindParticipantController = bindParticipantController;
//        }

//        public void SetOption(Option option)
//        {
//            _command.AddOption(option);
//        }

//        public Command Build()
//        {
//            SetOption(_bind);
//            SetOption(_name);
//            SetOption(_contribution);
//            SetOption(_bringDrink);
//            SetOption(_username);
//            SetOption(_addItems);

//            _command.SetHandler((bind, name, contribution, bringDrink, username, addItems) =>
//            {
//                CreateParticipantHandler(bind, name, contribution, bringDrink, username, addItems);
//            }, _bind, _name, _contribution, _bringDrink, _username, _addItems);
//            return _command;
//        }

//        private AddParticipantOutputBoundary CreateParticipantHandler(string bind, string name, string contribution, bool bringDrink, string username, string addItems)
//        {
//            var input = new AddParticipantInputBoundary(
//                name,
//                $"@{username}",
//                Convert.ToDouble(contribution),
//                bringDrink,
//                Guid.Parse(bind),
//                addItems.Split(';').AsEnumerable());

//            var output = _addParticipantController
//                .SetDistributedCache(new CachedRepository())
//                .Handle(input);

//            _bindParticipantController
//                .SetDistributedCache(new CachedRepository())
//                .Handle(new BindParticipantInputBoundary
//                {
//                    BarbecueIdentifier = input.BarbecueIdentifier,
//                    ParticipantIdentifier = output.ParticipantIdentifier,
//                });
//            Console.WriteLine($"Participant has successfully binded to Berbecue identified by {Guid.Parse(bind)}");

//            return new AddParticipantOutputBoundary
//            {
//                ParticipantIdentifier = Guid.NewGuid()
//            };
//        }
//    }
//}
