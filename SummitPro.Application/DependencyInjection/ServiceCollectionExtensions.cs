using Microsoft.Extensions.DependencyInjection;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.CreateBarbecue;

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
        }
    }
}
