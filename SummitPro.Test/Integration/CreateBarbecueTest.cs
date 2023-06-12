using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

using SummitPro.Infrastructure.RepositoryInMemory;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application;
using SummitPro.Infrastructure;
using SummitPro.Application.Query;
using SummitPro.Application.Repository;
using SummitPro.Infrastructure.DependencyInjector;
using SummitPro.Application.DependencyInjection;
using SummitPro.Application.Interface;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class CreateBarbecueTest
    {
        private IMediator _mediator;
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void SetUp()
        {
            //MediatR
            var services = new ServiceCollection();

            services.AddSingleton<IGateway<string>, Gateway>();
            services.AddSingleton<IBarbecueRepository, BarbecueRepositoryInMemory>();
            services.AddMediator();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddInfrastructureInMemory();
            services.AddUseCase();

            // Distributed Cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379";
                options.InstanceName = "redisinstance";
            });

            _serviceProvider = services.BuildServiceProvider();
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        [Test]
        public async Task ShouldCreateBarbecueByUsingDistributedCache()
        {
            // Arrange
            ICreateBarbecueUseCase createBarbecue = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = new CreateBarbecueInputBoundary
            {
                Description = "Description 01",
                BeginDate = DateTime.Parse("26/05/2025 01:00:00 -3:00"),
                EndDate = DateTime.Parse("26/05/2025 05:45:00 -3:00"),
                AdditionalObservations = additional
            };

            // Act
            var output = await createBarbecue.Execute(input);

            var query = await _mediator.Send(new GetBarbecueByIdQuery(output.BarbecueIdentifier));

            // Assert
            Assert.IsNotNull(query);
            Assert.IsNotNull(output);
            Assert.That(output.BarbecueIdentifier, Is.EqualTo(query.BarbecueIdentifier));
            Assert.That(input.Description, Is.EqualTo(query.Description));
        }

        //[Test]
        //public async Task ShouldUpdateBarbecue()
        //{
        //    // Arrange
        //    var createBarbecueUseCase = new CreateBarbecueUseCase(_mediator);
        //    var updateBarbecueUseCase = new UpdateBarbecueUseCase(_mediator);
        //    var getBarbecueByIdUseCase = new GetBarbecueByIdUseCase(_barbecueRepository);

        //    var additional = new List<string>
        //    {
        //        "Description 001",
        //        "Description 002",
        //        "Description 003",
        //    };

        //    var inputToCreateBarbecue = new CreateBarbecueInputBoundary
        //    {
        //        Description = "Description 01",
        //        BeginDate = DateTime.Parse("26/05/2025 01:00:00 -3:00"),
        //        EndDate = DateTime.Parse("26/05/2025 05:45:00 -3:00"),
        //        AdditionalObservations = additional
        //    };

        //    var outputToCreateBarbecue = await createBarbecueUseCase.Execute(inputToCreateBarbecue);

        //    var otherAdditional = new List<string>
        //    {
        //        "Description 001",
        //        "Description 002",
        //        "Description 003",
        //    };

        //    var inputToUpdateBarbecue = new UpdateBarbecueInputBoundary
        //    {
        //        BarbecueIdentifier = outputToCreateBarbecue.BarbecueIdentifier,
        //        AdditionalMarks = otherAdditional,
        //        Description = "Other Description",
        //        BeginDate = DateTime.Parse("26/06/2025 13:00:00 -3:00"),
        //        EndDate = DateTime.Parse("26/06/2025 17:30:00 -3:00"),
        //    };

        //    // Act
        //    await updateBarbecueUseCase.Execute(inputToUpdateBarbecue);

        //    GetBarbecueByIdOutputBoundary barbecue = getBarbecueByIdUseCase.Execute(new GetBarbecueByIdInputBoundary
        //    {
        //        BarbecueIdentifier = outputToCreateBarbecue.BarbecueIdentifier
        //    });

        //    // Assert
        //    Assert.That(barbecue.AdditionalRemarks.Count(), Is.EqualTo(6));
        //    Assert.That(DateTime.Parse(barbecue.BeginDateTime), Is.EqualTo(inputToUpdateBarbecue.BeginDate));
        //    Assert.That(DateTime.Parse(barbecue.EndDateTime), Is.EqualTo(inputToUpdateBarbecue.EndDate));
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
