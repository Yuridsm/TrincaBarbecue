using System.CommandLine;
using TrincaBarbecue.Infrastructure.Http.Controller;

namespace TrincaBarbecue.CommandLine
{
    public class ListBarbecueCLI
    {
        private readonly ListBarbecuesController _listBarbecuesController;
        private Command _command = new Command("list", "List Resouces");

        public ListBarbecueCLI(ListBarbecuesController listBarbecuesController)
        {
            _listBarbecuesController = listBarbecuesController;
        }

        public void SetCommand(Command command)
        {
            _command.AddCommand(command);
        }

        public Command Build()
        {
            _command.SetHandler(() =>
            {
                Handle();
            });
            return _command;
        }

        public void Handle()
        {
            Console.WriteLine("Teste executado com sucesso");
            var output = _listBarbecuesController.Handle();

            foreach (var item in output.Barbecues)
            {
                Console.WriteLine($"Create barbecue with Identifier    {item.barbecueIdentifier}:");
                Console.WriteLine($"   Description:                    {item.Description}");
                Console.WriteLine($"   Begin DateTime:                 {item.BeginDate}");
                Console.WriteLine($"   End DateTime:                   {item.EndDate}");

                foreach (var remark in item.AdditionalRemarks)
                {
                    Console.WriteLine($"   Additional Remarks:             {remark}");
                }

                foreach (var participant in item.Participants)
                {
                    Console.WriteLine($"    - Identifier:             {participant.Identifier}");
                    Console.WriteLine($"    - Name:             {participant.Name}");
                    Console.WriteLine($"    - Username:             {participant.Username}");
                    Console.WriteLine($"    - Contribution Value:             {participant.ContributionValue}");
                    Console.WriteLine($"    - Bring Drink:             {participant.BringDrink}");
                    

                    foreach(var value in participant.Items)
                    {
                        Console.WriteLine($"     - Item:             {value}");
                    }
                }
            }

        }
    }
}
