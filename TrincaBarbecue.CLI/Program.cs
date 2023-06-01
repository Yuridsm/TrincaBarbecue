using System.CommandLine;

namespace TrincaBarbecue.CLI;

class Program
{
    static async Task<int> Main(string[] args)
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
        var barbecueCommand = new Command("barbecue", "Barbecue Resouce");

        var createBarbecueCommand = new Command("create", "Create a new barbecue");

        createBarbecueCommand.AddOption(descriptionOption);
        createBarbecueCommand.AddOption(beginOption);
        createBarbecueCommand.AddOption(endOption);
        createBarbecueCommand.AddOption(remarkOption);

        barbecueCommand.AddCommand(createBarbecueCommand);
        
        rootCommand.AddCommand(barbecueCommand);
        #endregion

        #region Handlers
        createBarbecueCommand.SetHandler((name, begin, end, remark) =>
        {
            createBarbecueHandler(name, begin, end, remark);
        }, descriptionOption, beginOption, endOption, remarkOption);
        #endregion

        return await rootCommand.InvokeAsync(args);
    }

    public static void createBarbecueHandler(string description, string begin, string end, string remark)
    {
        Console.WriteLine($"Create barbecue with:");
        Console.WriteLine($"   Description:             {description}");
        Console.WriteLine($"   Begin DateTime:          {begin}");
        Console.WriteLine($"   End DateTime:            {end}");
        Console.WriteLine($"   Additional Remarks:      {remark}");
    }
}