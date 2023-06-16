using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.UseCase.CalculateMinimumContribution;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.GetBarbecueById;
using SummitPro.Application.UseCase.GetParticipant;
using SummitPro.Application.UseCase.ListBarbecues;
using SummitPro.Application.UseCase.UpdateBarbecue;

namespace SummitPro.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        }

        public static void AddUseCase(this IServiceCollection services)
        {
            services.AddScoped<ICreateBarbecueUseCase, CreateBarbecueUseCase>();
            services.AddScoped<IGetBarbecueByIdUseCase, GetBarbecueByIdUseCase>();
            services.AddScoped<IUpdateBarbecueUseCase, UpdateBarbecueUseCase>();
            services.AddScoped<IAddParticipantUseCase, AddParticipantUseCase>();
            services.AddScoped<IGetParticipantByIdUseCase, GetParticipantByIdUseCase>();
            services.AddScoped<IBindParticipantUseCase, BindParticipantUseCase>();
            services.AddScoped<IListBarbecuesUseCase, ListBarbecuesUseCase>();
            services.AddScoped<ICalculateMinimumContributionUseCase, CalculateMinimumContributionUseCase>();
        }

        public static void AddLog(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });
        }
    }
}
