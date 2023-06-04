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
        var createParticipantCommand = new CreateParticipantCLI();
        var createTrincaCommand = service.GetService<CreateBarbecueCLI>();
        var listTrincaCommand = service.GetService<ListBarbecueCLI>();

        var barbecue = new BarbecueCommand();
        barbecue.SetCommand(createTrincaCommand.Build());
        barbecue.SetCommand(listTrincaCommand.Build());

        participantCommand.SetCommand();
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
            
            .AddSingleton<CreateBarbecueUseCase>()
            .AddSingleton<AddParticipantUseCase>()
            .AddSingleton<BindParticipantUseCase>()
            .AddSingleton<GetBarbecueByIdUseCase>()
            .AddSingleton<GetParticipantsUseCase>()
            .AddSingleton<ListBarbecuesUseCase>()

            .AddSingleton<CreateBarbecueController>()
            .AddSingleton<AddParticipantController>()
            .AddSingleton<BindParticipantTobarbecueController>()
            .AddSingleton<GetbarbecueByIdController>()
            .AddSingleton<ListBarbecuesController>()

            .AddSingleton<CreateBarbecueCLI>()
            .AddSingleton<ListBarbecueCLI>()
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return serviceProvider.BuildServiceProvider();
    }
}
