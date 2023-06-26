using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SummitPro.Application.DependencyInjection;
using SummitPro.Application.Feature.GetBarbecueById;
using SummitPro.Application.Interface;
using SummitPro.Application.Repository;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.GetBarbecueById;
using SummitPro.Application.UseCase.UpdateBarbecue;
using SummitPro.Infrastructure.DependencyInjector;
using SummitPro.Infrastructure.RepositoryInMemory;
using SummitPro.SharedKernel.DomainException;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class CreateBarbecueTest
    {
        private IMediator _mediator = null!;
        private ServiceProvider _serviceProvider = null!;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();

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
        public async Task ShouldCreateBarbecueByUsingRepositoryInMemory()
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

        [Test]
        public async Task ShouldUpdateBarbecue()
        {
            // Arrange
            var createBarbecueUseCase = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();
            var updateBarbecueUseCase = _serviceProvider.GetRequiredService<IUpdateBarbecueUseCase>();
            var getBarbecueByIdUseCase = _serviceProvider.GetRequiredService<IGetBarbecueByIdUseCase>();

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var inputToCreateBarbecue = new CreateBarbecueInputBoundary
            {
                Description = "Description 01",
                BeginDate = DateTime.Parse("26/05/2025 01:00:00 -3:00"),
                EndDate = DateTime.Parse("26/05/2025 05:45:00 -3:00"),
                AdditionalObservations = additional
            };

            var outputToCreateBarbecue = await createBarbecueUseCase.Execute(inputToCreateBarbecue);

            var otherAdditional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var inputToUpdateBarbecue = new UpdateBarbecueInputBoundary
            {
                BarbecueIdentifier = outputToCreateBarbecue.BarbecueIdentifier,
                AdditionalMarks = otherAdditional,
                Description = "Other Description",
                BeginDate = DateTime.Parse("26/06/2025 13:00:00 -3:00"),
                EndDate = DateTime.Parse("26/06/2025 17:30:00 -3:00"),
            };

            // Act
            await updateBarbecueUseCase.Execute(inputToUpdateBarbecue);

            var updatedBarbecue = await getBarbecueByIdUseCase.Execute(new GetBarbecueByIdInputBoundary
            {
                BarbecueIdentifier = outputToCreateBarbecue.BarbecueIdentifier
            });

            // Assert
            Assert.That(updatedBarbecue.AdditionalRemarks.Count(), Is.EqualTo(6));
            Assert.That(DateTime.Parse(updatedBarbecue.BeginDateTime), Is.EqualTo(inputToUpdateBarbecue.BeginDate));
            Assert.That(DateTime.Parse(updatedBarbecue.EndDateTime), Is.EqualTo(inputToUpdateBarbecue.EndDate));
        }

        [Test]
        public void ShouldThrowException_WhetherDateTimeDoesNotMatchWithNow()
        {
            // Arrange
            var barbecue = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = new CreateBarbecueInputBoundary
            {
                Description = "Our first barbecue",
                AdditionalObservations = additional,
                BeginDate = DateTime.Parse("26/05/2025 05:42:00 -3:00"),
                EndDate = DateTime.Parse("26/05/2023 05:42:00 -3:00")
            };

            // Act & Assert
            Assert.ThrowsAsync<DateTimeDoesNotMatchException>(async () =>
            {
                var identifier = await barbecue.Execute(input);
            });
        }
    }
}
