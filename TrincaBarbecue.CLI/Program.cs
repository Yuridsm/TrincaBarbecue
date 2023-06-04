using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.BindParticipant;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Application.UseCase.GetParticipant;
using TrincaBarbecue.Application.UseCase.ListBarbecues;
using TrincaBarbecue.CLI.CommandLine;
using TrincaBarbecue.CommandLine;
using TrincaBarbecue.Infrastructure.DependencyInjector;
using TrincaBarbecue.Infrastructure.Http.Controller;

namespace TrincaBarbecue.CLI;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Trinca Command-Line Interface");
        var service = ConfigureServices();

        var participantCommand = new ParticipantCommand();

        var createParticipantCommand = service.GetService<CreateParticipantCLI>();
        var createTrincaCommand = service.GetService<CreateBarbecueCLI>();
        var listTrincaCommand = service.GetService<ListBarbecueCLI>();

        // Subcommands
        participantCommand.SetCommand(createParticipantCommand.Build());

        var barbecue = new BarbecueCommand();
        barbecue.SetCommand(createTrincaCommand.Build());
        barbecue.SetCommand(listTrincaCommand.Build());
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
            .AddScoped<GetParticipantsUseCase>()
            .AddScoped<ListBarbecuesUseCase>()

            .AddScoped<CreateBarbecueController>()
            .AddScoped<AddParticipantController>()
            .AddScoped<BindParticipantTobarbecueController>()
            .AddScoped<GetbarbecueByIdController>()
            .AddScoped<ListBarbecuesController>()

            .AddScoped<CreateBarbecueCLI>()
            .AddScoped<ListBarbecueCLI>()
            .AddScoped<CreateParticipantCLI>()
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return serviceProvider.BuildServiceProvider();
    }
}
