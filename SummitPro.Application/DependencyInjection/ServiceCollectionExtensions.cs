using Microsoft.Extensions.DependencyInjection;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.GetBarbecueById;
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
            services.AddScoped<IBindParticipantUseCase, BindParticipantUseCase>();
        }
    }
}
