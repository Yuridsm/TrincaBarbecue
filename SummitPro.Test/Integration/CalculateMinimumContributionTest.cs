using AutoMapper;
using NUnit.Framework;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.Core.Aggregate.Participant;
using SummitPro.Infrastructure.RepositoryInMemory.Models;
using SummitPro.Application.UseCase.CalculateMinimumContribution;
using SummitPro.Infrastructure.RepositoryInMemory;

namespace SummitPro.Test.Integration
{
    public class CalculateMinimumContributionTest
    {
        private Mapper _mapper;

        [SetUp]
        public void SetUp()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<BarbecueModelMapperProfile>();
                config.AddProfile<ParticipantModelMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [Test]
        public void ShouldCalculateMinimumContributionValue()
        {
            // Arrange

            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var participantRepository = new ParticipantRepositoryInMemory(_mapper);

            var add = new List<string>
            {
                "Chegue no horário",
                "Beba conciente",
                "Pode dançar a vontade, viu?!"
            };

            var barbecue = Barbecue.FactoryMethod("Friends from Work!", add, DateTime.Parse("23/12/2023 13:00:00 -3:00"), DateTime.Parse("23/12/2023 17:30:00 -3:00"));

            var participant01 = Participant.FactoryMethod("Yuri Melo", "@yuridsm", 100.00f);
            var participant02 = Participant.FactoryMethod("Júlio Miguel", "@ojuliomiguel", 100.00f);
            var participant03 = Participant.FactoryMethod("Beatriz Nunes", "@beatriz", 100.00f);

            participantRepository.Add(participant01);
            participantRepository.Add(participant02);
            participantRepository.Add(participant03);

            barbecue
                .AddParticipant(participant01.Identifier)
                .AddParticipant(participant02.Identifier)
                .AddParticipant(participant03.Identifier)
                .AddAdditionalRemark("Mais uma informação importante para o evento.")
                .AddDescription("Atualização da descrição do Churras da Trinca!! Não perca!!!")
                .Build();

            barbecueRepository.Add(barbecue);

            var useCase = new CalculateMinimumContributionUseCase(barbecueRepository, participantRepository);

            // Act
            var contribution = useCase.Execute(new CalculateContributionInputBoundary
            {
                BarecueIdentifier = barbecue.Identifier
            });

            // Assert
            Assert.That(contribution.Value, Is.EqualTo(100.00d));
        }
    }
}
