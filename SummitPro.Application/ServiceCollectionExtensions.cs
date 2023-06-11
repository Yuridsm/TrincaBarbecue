using Microsoft.Extensions.DependencyInjection;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.CreateBarbecue;

namespace SummitPro.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUseCase(this IServiceCollection services)
        {
            services.AddScoped<ICreateBarbecueUseCase, CreateBarbecueUseCase>();
        }
    }
}
