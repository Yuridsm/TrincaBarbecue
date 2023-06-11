using Microsoft.Extensions.DependencyInjection;
using SummitPro.Infrastructure.DependencyInjector;

namespace SummitPro.CompositionRoot.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBasicServices(this IServiceCollection services)
        {
            services.AddInfrastructureInMemory();
        }
    }
}
