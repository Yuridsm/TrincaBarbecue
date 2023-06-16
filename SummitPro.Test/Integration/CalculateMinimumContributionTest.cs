using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using SummitPro.Application.DependencyInjection;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.Application.UseCase.CalculateMinimumContribution;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Infrastructure.DependencyInjector;

namespace SummitPro.Test.Integration
{
    public class CalculateMinimumContributionTest
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
        public async Task ShouldCalculateMinimumContributionValue()
        {
            // Arrange
            var createBarbecueUSeCase = _serviceProvider.GetRequiredService<ICreateBarbecueUseCase>();
            var addParticipantUseCase = _serviceProvider.GetRequiredService<IAddParticipantUseCase>();
            var bindParticipantUseCase = _serviceProvider.GetRequiredService<IBindParticipantUseCase>();
            var calculateContributionUseCase = _serviceProvider.GetRequiredService<ICalculateMinimumContributionUseCase>();

            var add = new List<string>
            {
                "Chegue no horário",
                "Beba conciente",
                "Pode dançar a vontade, viu?!"
            };

            var barbecue = await createBarbecueUSeCase.Execute(new CreateBarbecueInputBoundary
            {
                AdditionalObservations = add,
                BeginDate = DateTime.Parse("23/12/2023 13:00:00 -3:00"),
                EndDate = DateTime.Parse("23/12/2023 17:00:00 -3:00"),
                Description = "Friends from work!"
            });

            var participant01 = addParticipantUseCase.Execute(new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 100.00f, true, barbecue.BarbecueIdentifier, new List<string>(0)));
            var participant02 = addParticipantUseCase.Execute(new AddParticipantInputBoundary("Igor Melo", "@igordsm", 100.00f, true, barbecue.BarbecueIdentifier, new List<string>(0)));
            var participant03 = addParticipantUseCase.Execute(new AddParticipantInputBoundary("iran Melo", "@irandsm", 100.00f, true, barbecue.BarbecueIdentifier, new List<string>(0)));

            await bindParticipantUseCase.Execute(new BindParticipantInputBoundary
            {
                BarbecueIdentifier = barbecue.BarbecueIdentifier,
                ParticipantIdentifier = participant01.ParticipantIdentifier
            });

            await bindParticipantUseCase.Execute(new BindParticipantInputBoundary
            {
                BarbecueIdentifier = barbecue.BarbecueIdentifier,
                ParticipantIdentifier = participant02.ParticipantIdentifier
            });

            await bindParticipantUseCase.Execute(new BindParticipantInputBoundary
            {
                BarbecueIdentifier = barbecue.BarbecueIdentifier,
                ParticipantIdentifier = participant03.ParticipantIdentifier
            });

            // Act
            var output = await calculateContributionUseCase.Execute(new CalculateContributionInputBoundary
            {
                BarecueIdentifier = barbecue.BarbecueIdentifier
            });

            // Assert
            Assert.That(output.Value, Is.EqualTo(300.00d));
        }
    }
}
