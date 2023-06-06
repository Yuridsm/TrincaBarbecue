using Microsoft.Extensions.DependencyInjection;

namespace SummitPro.Infrastructure.DependencyInjector
{
    public static class ServiceCollectionFactoryMethod
    {
        private static IServiceCollection _service;

        public static IServiceCollection services
        {
            get
            {
                return _service ?? (_service = new ServiceCollection());
            }
        }
    }
}
