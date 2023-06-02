using Microsoft.Extensions.DependencyInjection;
using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Infrastructure.DistributedCache;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.DependencyInjector
{
    public static class InfrastructureDIExtensions
    {
        public static IServiceCollection AddInfrastructureInMemory(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(ICachedRepository<>), typeof(CachedRepository<>))
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
