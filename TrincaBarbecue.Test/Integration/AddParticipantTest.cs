using AutoMapper;
using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Test.Integration
{
    [TestFixture]
    public class AddParticipantTest
    {
        private Mapper _mapper;

        [SetUp]
        public void SetUp()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<ParticipantModelMapperProfile>();
                config.AddProfile<BarbecueModelMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [Test]
        public void ShouldCreateParticipant()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var participantRepository = new ParticipantRepositoryInMemory(_mapper);
            var participantUseCase = new AddParticipantUseCase(barbecueRepository, participantRepository);
            var barbecueUseCase = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var barbecueInput = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
            var barbecueOutput = barbecueUseCase
                .Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var participantInput = new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 200.00f, true, Guid.Parse(barbecueOutput.GetIdentifier()), items);

            // Act
            var outputParticipant = participantUseCase
                .Execute(participantInput);
            var oneParticipant = participantRepository.Find(o => o.Identifier == outputParticipant.ParticipantIdentifier);

            // Assert
            Assert.That(outputParticipant.ParticipantIdentifier, Is.EqualTo(oneParticipant.Identifier));
        }
    }
}
