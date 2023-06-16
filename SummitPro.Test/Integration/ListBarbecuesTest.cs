using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using SummitPro.Application;
using SummitPro.Application.DependencyInjection;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Infrastructure;
using SummitPro.Infrastructure.DependencyInjector;

namespace SummitPro.Test.Integration
{
    [TestFixture]
    public class ListBarbecuesTest
    {
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IGateway<string>, Gateway>();
            services.AddMediator();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddInfrastructureInMemory();
            services.AddLog();
            services.AddUseCase();

            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public async Task ShouldListAllExistingBarbecues()
        {
            // Arrange
            var barbecueUseCase = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();
            var participantUseCase = _serviceProvider.GetRequiredService<IAddParticipantUseCase>();
            var bindParticipant = _serviceProvider.GetRequiredService<IBindParticipantUseCase>();
            var listBarbecues = _serviceProvider.GetRequiredService<IListBarbecuesUseCase>();

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003"
            };

            var barbecueInput = new CreateBarbecueInputBoundary
            {
                Description = "Description 01",
                BeginDate = DateTime.Parse("26/05/2025 01:00:00 -3:00"),
                EndDate = DateTime.Parse("26/05/2025 05:42:00 -3:00"),
                AdditionalObservations = additional
            };

            var barbecueOutput = await barbecueUseCase.Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var participantInput = new AddParticipantInputBoundary(
                "Yuri Melo", 
                "@yuridsm", 
                100.00f, 
                false, 
                barbecueOutput.BarbecueIdentifier, 
                items);

            var participantOutput = participantUseCase.Execute(participantInput);

            var bindParticipantInput = new BindParticipantInputBoundary
            {
                BarbecueIdentifier = barbecueOutput.BarbecueIdentifier,
                ParticipantIdentifier = participantOutput.ParticipantIdentifier
            };

            // Act
            await bindParticipant.Execute(bindParticipantInput);

            var output = await listBarbecues.Execute();

            var participantIdentifiers = output.Barbecues.SelectMany(o => o.Participants.Select(o => o.Identifier));

            // Assert
            Assert.IsNotNull(output);
            Assert.Contains(participantOutput.ParticipantIdentifier, participantIdentifiers.ToList());
        }
    }
}
