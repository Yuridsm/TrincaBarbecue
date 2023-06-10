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
using MediatR;
using SummitPro.Application.Command.Handler;
using SummitPro.Application;
using SummitPro.Infrastructure;
using System.Reflection;
using SummitPro.Application.Query;
using SummitPro.Application.Repository;
using SummitPro.Infrastructure.DependencyInjector;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class CreateBarbecueTest
    {
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            //MediatR
            var services = new ServiceCollection();

            services.AddSingleton<IGateway<string>, Gateway>();
            services.AddSingleton<IBarbecueRepository, BarbecueRepositoryInMemory>();
            services.AddApplicationConfiguration();

            // Distributed Cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "redisinstance";
            });

            var serviceProvider = services.BuildServiceProvider();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        [Test]
        public async Task ShouldAddEntityInDistributedCache()
        {
            // Arrange
            var distributedCache = new CachedRepository();

            var createBarbecue = new CreateBarbecueUseCase(_mediator)
                .SetDistributedCache(distributedCache);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var output = await createBarbecue.Execute(input);
            var query = _mediator.Send(new GetBarbecueByIdQuery(Guid.Parse(output.GetIdentifier())));

            // Assert
            Assert.IsNotNull(query);
            Assert.IsNotNull(output);
        }

        //[Test]
        //public void ShouldCreateBarbecue()
        //{
        //    // Arrange
        //    var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
        //    var barbecue = new CreateBarbecueUseCase(_mediators)
        //        .SetDistributedCache(_distributedCache);

        //    var additional = new List<string>
        //    {
        //        "Description 001",
        //        "Description 002",
        //        "Description 003",
        //    };

        //    var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

        //    // Act
        //    var output = barbecue.Execute(input);
        //    var sanitizedData = Guid.Parse(output.GetIdentifier());
        //    var instance = barbecueRepository.Get(sanitizedData);

        //    // Assert
        //    Assert.That(output.GetIdentifier(), Is.EqualTo(instance?.Identifier.ToString()));
        //}

        //[Test]
        //public void ShouldUpdateBarbecue()
        //{
        //    // Arrange
        //    var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
        //    var barbecue = new CreateBarbecueUseCase(barbecueRepository);
        //    var additional = new List<string>
        //    {
        //        "Description 001",
        //        "Description 002",
        //        "Description 003",
        //    };

        //    var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

        //    var participant = Participant
        //        .FactoryMethod("Iran Melo", "@irandsm", 100.50f)
        //        .AddItem("Refriiii")
        //        .AddBringDrink(true)
        //        .UpdateUsername("@iranmelo")
        //        .Build();

        //    var output = barbecue.Execute(input);
        //    var sanitizedData = Guid.Parse(output.GetIdentifier());
        //    var instance = barbecueRepository.Get(sanitizedData);
        //    instance.AddAdditionalRemark("Outra Remark adicionado");

        //    // Act
        //    barbecueRepository.Update(instance);
        //    instance = barbecueRepository.Get(sanitizedData);

        //    // Assert
        //    Assert.That(output.GetIdentifier(), Is.EqualTo(instance?.Identifier.ToString()));
        //    Assert.That(instance.AdditionalRemarks.Count(), Is.EqualTo(4));
        //}

        //[Test]
        //public void ShouldThrowException_WhetherDateTimeDoesNotMatchWithNow()
        //{
        //    // Arrange
        //    var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
        //    var barbecue = new CreateBarbecueUseCase(barbecueRepository);
        //    var additional = new List<string>
        //    {
        //        "Description 001",
        //        "Description 002",
        //        "Description 003",
        //    };

        //    var input = CreateInputBoundary.FactoryMethod("Trinca Churras", additional, DateTime.Parse("26/05/2025 05:42:00 -3:00"), DateTime.Parse("26/05/2023 05:42:00 -3:00"));

        //    // Act & Assert
        //    Assert.Throws<DateTimeDoesNotMatchException>(() =>
        //    {
        //        var identifier = barbecue.Execute(input);
        //    });
        //}
    }
}
