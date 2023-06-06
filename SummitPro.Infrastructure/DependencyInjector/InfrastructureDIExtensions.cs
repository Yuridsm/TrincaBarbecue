using Microsoft.Extensions.DependencyInjection;
using SummitPro.Application.Repository;
using SummitPro.Infrastructure.DistributedCache;
using SummitPro.Infrastructure.RepositoryInMemory;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Infrastructure.DependencyInjector
{
    public static class InfrastructureDIExtensions
    {
        public static IServiceCollection AddInfrastructureInMemory(this IServiceCollection services)
        {
            services
                .AddScoped<ICachedRepository, CachedRepository>()
                .AddSingleton<IBarbecueRepository, BarbecueRepositoryInMemory>()
                .AddSingleton<IParticipantRepository, ParticipantRepositoryInMemory>()
                .AddStackExchangeRedisCache(cache =>
                {
                    cache.InstanceName = "redisinstance";
                    cache.Configuration = "localhost:6379";
                });

            return services;
        }
    }
}
