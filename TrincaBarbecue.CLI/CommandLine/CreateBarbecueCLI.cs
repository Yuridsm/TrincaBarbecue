using System.CommandLine;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Infrastructure.Http.Controller;

namespace TrincaBarbecue.CommandLine
{
    public class CreateBarbecueCLI
    {
        private readonly CreateBarbecueController _createBarbecueController;

        public CreateBarbecueCLI(CreateBarbecueController createBarbecueController)
        {
            _createBarbecueController = createBarbecueController;
        }

        public RootCommand Run()
        {
            var rootCommand = new RootCommand("Trinca Command-Line Interface");

            #region Options
            var descriptionOption = new Option<string>(
                name: "--description",
                description: "Add description to resource like Barbecue");

            var beginOption = new Option<string>(
                name: "--begin",
                description: "Add begin Date time to resource like Barbecue. Ex.: 12/01/2024 13:00:00 -3:00");

            var endOption = new Option<string>(
                name: "--end",
                description: "Add end Date time to resource like Barbecue. Ex.: 12/01/2024 14:30:00 -3:00");

            var remarkOption = new Option<string>(
                name: "--remark",
                description: "Add additional remarks to resource like Barbecue. Use ; for multiples. Ex.: 'Bring drink;Have fun!'");
            #endregion

            #region Commands
            var trinca = new Command("trinca", "Trinca CLI");
            var barbecueCommand = new Command("barbecue", "Barbecue Resouce");

            var createBarbecueCommand = new Command("create", "Create a new barbecue");

            createBarbecueCommand.AddOption(descriptionOption);
            createBarbecueCommand.AddOption(beginOption);
            createBarbecueCommand.AddOption(endOption);
            createBarbecueCommand.AddOption(remarkOption);

            barbecueCommand.AddCommand(createBarbecueCommand);

            trinca.AddCommand(barbecueCommand);

            rootCommand.AddCommand(trinca);
            #endregion

            #region Handlers
            createBarbecueCommand.SetHandler((name, begin, end, remark) =>
            {
                createBarbecueHandler(name, begin, end, remark);
            }, descriptionOption, beginOption, endOption, remarkOption);
            #endregion

            return rootCommand;
        }

        public void createBarbecueHandler(string description, string begin, string end, string remark)
        {

            var input = CreateInputBoundary.FactoryMethod
                (description = description,
                new List<string> { remark },
                DateTime.Parse(begin),
                DateTime.Parse(end));

            var output = _createBarbecueController.Handle(input);

            Console.WriteLine($"Create barbecue with Identifier {output.GetIdentifier()}:");
            Console.WriteLine($"   Description:             {description}");
            Console.WriteLine($"   Begin DateTime:          {begin}");
            Console.WriteLine($"   End DateTime:            {end}");
            Console.WriteLine($"   Additional Remarks:      {remark}");
        }
    }
}
