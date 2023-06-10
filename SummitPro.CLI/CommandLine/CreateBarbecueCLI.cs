using SummitPro.Infrastructure.Http.Controller;
using System.CommandLine;
using SummitPro.Infrastructure.DistributedCache;
using SummitPro.Application.UseCase.CreateBarbecue;

namespace SummitPro.CLI.CommandLine
{
    public class CreateBarbecueCLI
    {
        private readonly CreateBarbecueController _createBarbecueController;
        private Command _command = new Command("create", "Create a new barbecue");

        private readonly Option<string> _descriptionOption = new Option<string>("--description", description: "Add description to resource like Barbecue");
        private readonly Option<string> _beginOption = new Option<string>("--begin", "Add begin Date time to resource like Barbecue. Ex.: 12/01/2024 13:00:00 -3:00");
        private readonly Option<string> _endOption = new Option<string>("--end", "Add end Date time to resource like Barbecue. Ex.: 12/01/2024 14:30:00 -3:00");
        private readonly Option<string> _remarkOption = new Option<string>("--remark", "Add additional remarks to resource like Barbecue. Use ; for multiples. Ex.: 'Bring drink;Have fun!'");

        public CreateBarbecueCLI(CreateBarbecueController createBarbecueController)
        {
            _createBarbecueController = createBarbecueController;
        }

        public void SetOption(Option option)
        {
            _command.AddOption(option);
        }

        public Command Build()
        {
            SetOption(_descriptionOption);
            SetOption(_beginOption);
            SetOption(_endOption);
            SetOption(_remarkOption);

            _command.SetHandler((name, begin, end, remark) =>
            {
                createBarbecueHandler(name, begin, end, remark);
            }, _descriptionOption, _beginOption, _endOption, _remarkOption);

            return _command;
        }

        private async Task createBarbecueHandler(string description, string begin, string end, string remark)
        {
            var input = new CreateBarbecueInputBoundary
            {
                Description = description,
                BeginDate = DateTime.Parse(begin),
                EndDate = DateTime.Parse(end),
                AdditionalObservations = new List<string> { remark }
            };

            _createBarbecueController
                .SetDistributedCache(new CachedRepository());

            var output = await _createBarbecueController.Handle(input);

            Console.WriteLine($"Create barbecue with Identifier {output.BarbecueIdentifier}:");
            Console.WriteLine($"   Description:             {description}");
            Console.WriteLine($"   Begin DateTime:          {begin}");
            Console.WriteLine($"   End DateTime:            {end}");
            Console.WriteLine($"   Additional Remarks:      {remark}");
        }
    }
}
