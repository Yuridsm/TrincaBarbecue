using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using SummitPro.Application.DependencyInjection;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Application.UseCase.GetParticipant;
using SummitPro.Infrastructure.DependencyInjector;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class GetParticipantsTest
    {
        private ServiceProvider _serviceProvider;

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
        }

        [Test]
        public async Task ShouldGetParticipants()
        {
            // Arrange
            var barbecueUseCase = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();
            var participantUseCase = _serviceProvider.GetRequiredService<IAddParticipantUseCase>();
            var getParticipantsUseCase = _serviceProvider.GetRequiredService<IGetParticipantByIdUseCase>();

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003"
            };

            var barbecueInput = new CreateBarbecueInputBoundary
            {
                Description = "Description 01",
                AdditionalObservations = additional,
                BeginDate = DateTime.Parse("26/05/2025 01:00:00 -3:00"),
                EndDate = DateTime.Parse("26/05/2025 05:42:00 -3:00"),
            };
            
            var barbecueOutput = await barbecueUseCase.Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var participantInput = new AddParticipantInputBoundary("Iran Melo", "@irandsm", 100.00f, false, barbecueOutput.BarbecueIdentifier, items);
            
            var participantOutput = participantUseCase.Execute(participantInput);

            // Act
            var getParticipants = await getParticipantsUseCase.Execute(new GetParticipantByIdInputBoundary
            {
                ParticipantIdentifier = participantOutput.ParticipantIdentifier
            });

            // Assert
            Assert.IsNotNull(getParticipants);
            Assert.That(participantOutput.ParticipantIdentifier, Is.EqualTo(getParticipants.Participant.Identifier));
        }
    }
}
