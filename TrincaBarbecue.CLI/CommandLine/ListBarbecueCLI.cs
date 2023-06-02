using System.CommandLine;
using TrincaBarbecue.Infrastructure.Http.Controller;

namespace TrincaBarbecue.CommandLine
{
    public class ListBarbecueCLI
    {
        private readonly CreateBarbecueController _createBarbecueController;

        public ListBarbecueCLI(CreateBarbecueController createBarbecueController)
        {
            _createBarbecueController = createBarbecueController;
        }

        public RootCommand Run()
        {
            var rootCommand = new RootCommand("Trinca Command-Line Interface");

            #region Commands
            var trinca = new Command("trinca", "Trinca CLI");
            var barbecueCommand = new Command("barbecue", "Barbecue Resouce");
            var listBarbecueCommand = new Command("list", "Barbecue Resouce");

            barbecueCommand.AddCommand(listBarbecueCommand);
            trinca.AddCommand(barbecueCommand);
            rootCommand.AddCommand(trinca);
            #endregion

            #region Handlers
            listBarbecueCommand.SetHandler(() =>
            {
                Handle();
            });
            #endregion

            return rootCommand;
        }

        public void Handle()
        {
            Console.WriteLine("Teste executado com sucesso");
            //Console.WriteLine($"Create barbecue with Identifier    {output.GetIdentifier()}:");
            //Console.WriteLine($"   Description:                    {description}");
            //Console.WriteLine($"   Begin DateTime:                 {begin}");
            //Console.WriteLine($"   End DateTime:                   {end}");
            //Console.WriteLine($"   Additional Remarks:             {remark}");
        }
    }
}
