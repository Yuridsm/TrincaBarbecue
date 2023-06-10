using Microsoft.Extensions.DependencyInjection;

namespace SummitPro.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            return services;
        }
    }
}
