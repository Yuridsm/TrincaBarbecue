using Microsoft.Extensions.DependencyInjection;

namespace SummitPro.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services
                .AddMediatR(o => o.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
    
            return services;
        }
    }
}
