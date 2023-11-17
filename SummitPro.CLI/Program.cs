using Microsoft.Extensions.DependencyInjection;
using SummitPro.Application.DependencyInjection;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.GetBarbecueById;
using SummitPro.Application.UseCase.ListBarbecues;
using SummitPro.CLI.CommandLine;
using SummitPro.Infrastructure.DependencyInjector;
using SummitPro.Infrastructure.Http.Controller;
using System.CommandLine;

namespace SummitPro.CLI;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Trinca Command-Line Interface");
        var service = ConfigureServices();

        var participantCommand = new ParticipantCommand();

        //var createParticipantCommand = service.GetService<CreateParticipantCLI>();
        var createTrincaCommand = service.GetService<CreateBarbecueCLI>();
        //var listTrincaCommand = service.GetService<ListBarbecueCLI>();

        // Subcommands
        //participantCommand.SetCommand(createParticipantCommand.Build());

        var barbecue = new BarbecueCommand();
        if (createTrincaCommand is not null) barbecue.SetCommand(createTrincaCommand.Build());
        //barbecue.SetCommand(listTrincaCommand.Build());
        barbecue.SetCommand(participantCommand.Build());

        var trinca = new TrincaCommand();
        trinca.SetCommand(barbecue.Build());

        rootCommand.AddCommand(trinca.Build());
        return await rootCommand.InvokeAsync(args);
    }

    public static IServiceProvider ConfigureServices()
    {
        var serviceProvider = ServiceCollectionFactoryMethod.services
            .AddInfrastructureInMemory()

            .AddScoped<CreateBarbecueUseCase>()
            .AddScoped<AddParticipantUseCase>()
            .AddScoped<BindParticipantUseCase>()
            .AddScoped<GetBarbecueByIdUseCase>()
            //.AddScoped<GetParticipantsUseCase>()
            .AddScoped<ListBarbecuesUseCase>()

            .AddScoped<CreateBarbecueController>()
            //.AddScoped<AddParticipantController>()
            .AddScoped<BindParticipantTobarbecueController>()
            //.AddScoped<GetbarbecueByIdController>()
            //.AddScoped<ListBarbecuesController>()

            .AddScoped<CreateBarbecueCLI>();
		    //.AddScoped<ListBarbecueCLI>()
		    //.AddScoped<CreateParticipantCLI>()
		    serviceProvider.AddMediator();


		return serviceProvider.BuildServiceProvider();
    }
}
