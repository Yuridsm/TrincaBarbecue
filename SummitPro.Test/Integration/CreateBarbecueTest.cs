using AutoMapper;
using NUnit.Framework;
using SummitPro.SharedKernel.DomainException;
using SummitPro.Infrastructure.RepositoryInMemory;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using SummitPro.Core.Aggregate.Participant;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Infrastructure.RepositoryInMemory.Models;
using SummitPro.Infrastructure.DistributedCache;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class CreateBarbecueTest
    {
        private Mapper _mapper;
        private IDistributedCache _cache;
        private CachedRepository _distributedCache = new CachedRepository();

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

            // Mapping
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<BarbecueModelMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [Test]
        public void ShouldAddEntityInDistributedCache()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var distributedCache = new CachedRepository();

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

        [Test]
        public void ShouldCreateBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var barbecue = new CreateBarbecueUseCase(barbecueRepository)
                .SetDistributedCache(_distributedCache);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var output = barbecue.Execute(input);
            var sanitizedData = Guid.Parse(output.GetIdentifier());
            var instance = barbecueRepository.Get(sanitizedData);

            // Assert
            Assert.That(output.GetIdentifier(), Is.EqualTo(instance?.Identifier.ToString()));
        }

        [Test]
        public void ShouldUpdateBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var barbecue = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            var participant = Participant
                .FactoryMethod("Iran Melo", "@irandsm", 100.50f)
                .AddItem("Refriiii")
                .AddBringDrink(true)
                .UpdateUsername("@iranmelo")
                .Build();

            var output = barbecue.Execute(input);
            var sanitizedData = Guid.Parse(output.GetIdentifier());
            var instance = barbecueRepository.Get(sanitizedData);
            instance.AddAdditionalRemark("Outra Remark adicionado");

            // Act
            barbecueRepository.Update(instance);
            instance = barbecueRepository.Get(sanitizedData);

            // Assert
            Assert.That(output.GetIdentifier(), Is.EqualTo(instance?.Identifier.ToString()));
            Assert.That(instance.AdditionalRemarks.Count(), Is.EqualTo(4));
        }

        [Test]
        public void ShouldThrowException_WhetherDateTimeDoesNotMatchWithNow()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var barbecue = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Trinca Churras", additional, DateTime.Parse("26/05/2025 05:42:00 -3:00"), DateTime.Parse("26/05/2023 05:42:00 -3:00"));

            // Act & Assert
            Assert.Throws<DateTimeDoesNotMatchException>(() =>
            {
                var identifier = barbecue.Execute(input);
            });
        }
    }
}
