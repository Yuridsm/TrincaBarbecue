using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.BindParticipant;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Application.UseCase.GetParticipant;
using TrincaBarbecue.CommandLine;
using TrincaBarbecue.Infrastructure.Http.Controller;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;

namespace TrincaBarbecue.CLI;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var serviceProvider = ConfigureServices();
        var start = serviceProvider.GetService<ListBarbecueCLI>();

        var rootCommand = start.Run();

        return await rootCommand.InvokeAsync(args);
    }

    public static IServiceProvider ConfigureServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IBarbecueRepository, BarbecueRepositoryInMemory>()
            .AddSingleton<IParticipantRepository, ParticipantRepositoryInMemory>()
            .AddScoped<CreateBarbecueUseCase>()
            .AddScoped<AddParticipantUseCase>()
            .AddScoped<BindParticipantUseCase>()
            .AddScoped<GetBarbecueByIdUseCase>()
            .AddScoped<GetParticipantsUseCase>()
            .AddScoped<CreateBarbecueController>()
            .AddScoped<AddParticipantController>()
            .AddScoped<BindParticipantTobarbecueController>()
            .AddScoped<GetbarbecueByIdController>()
            .AddTransient<CreateBarbecueCLI>()
            .AddTransient<ListBarbecueCLI>()
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return serviceProvider.BuildServiceProvider();
    }
}
