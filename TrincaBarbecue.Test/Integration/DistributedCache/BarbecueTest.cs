using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.Infrastructure.DistributedCache;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Test.Integration.DistributedCache
{
    [TestFixture]
    public class BarbecueTest
    {
        private Mapper _mapper;
        private IDistributedCache _cache;
        private CachedRepository<Barbecue> _distributedCache = new CachedRepository<Barbecue>();

        [SetUp]
        public void SetUp()
        {
            // Distributed Cache
            var services = new ServiceCollection();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "redisinstance";
            });

            var serviceProvider = services.BuildServiceProvider();
            _cache = serviceProvider.GetRequiredService<IDistributedCache>();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<ParticipantModelMapperProfile>();
                config.AddProfile<BarbecueModelMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [Test]
        public void ShouldCreateBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var distributedCache = new CachedRepository<Barbecue>();

            var createBarbecue = new CreateBarbecueUseCase(barbecueRepository)
                .SetDistributedCache(distributedCache);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var output = createBarbecue.Execute(input);

            // Assert
            Assert.IsNotNull(output);
        }

    }
}
