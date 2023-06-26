using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SummitPro.Application.DependencyInjection;
using SummitPro.Application.Feature.GetBarbecueById;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Infrastructure.DependencyInjector;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class AddParticipantTest
    {
        private IMediator _mediator = null!;
        private ServiceProvider _serviceProvider = null!;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();

            services.AddMediator();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddInfrastructureInMemory();
            services.AddUseCase();
            services.AddLog();

            _serviceProvider = services.BuildServiceProvider();
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        [Test]
        public async Task ShouldBindParticipantTobarbecue()
        {
            // Arrange
            var barbecueUseCase = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();
            var participantUseCase = _serviceProvider.GetRequiredService<IAddParticipantUseCase>();
            var bindParticipantToBarbecue = _serviceProvider.GetRequiredService<IBindParticipantUseCase>();

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var barbecueInput = new CreateBarbecueInputBoundary
            {
                AdditionalObservations = additional,
                Description = "Description Here",
                BeginDate = DateTime.Parse("26/05/2025 01:00:00 -3:00"),
                EndDate = DateTime.Parse("26/05/2025 05:42:00 -3:00")
            };
            
            var barbecueOutput = await barbecueUseCase.Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var participantInput = new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 200.00f, true, barbecueOutput.BarbecueIdentifier, items);

            var participantOutput = participantUseCase.Execute(participantInput);
            // Act
            await bindParticipantToBarbecue.Execute(new BindParticipantInputBoundary
            {
                BarbecueIdentifier = barbecueOutput.BarbecueIdentifier,
                ParticipantIdentifier = participantOutput.ParticipantIdentifier
            });

            var query = await _mediator.Send(new GetBarbecueByIdQuery(barbecueOutput.BarbecueIdentifier));

            // Assert
            Assert.Contains(participantOutput.ParticipantIdentifier, query.Participants.ToList());
        }
    }
}
