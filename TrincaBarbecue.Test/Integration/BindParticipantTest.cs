using AutoMapper;
using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.BindParticipant;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Test.Integration
{
    [TestFixture]
    public class BindParticipantTest
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
        public void ShouldBindParticipanttoExistingBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var participantRepository = new ParticipantRepositoryInMemory(_mapper);
            var barbecueUseCase = new CreateBarbecueUseCase(barbecueRepository);
            var participantUseCase = new AddParticipantUseCase(barbecueRepository, participantRepository);
            var bindParticipant = new BindParticipantUseCase(barbecueRepository, participantRepository);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",

            };
            var barbecueInput = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
            var barbecueOutput = barbecueUseCase.Execute(barbecueInput);

            var participantInput = new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 100.00f, false, Guid.Parse(barbecueOutput.GetIdentifier()));

            var participantOutput = participantUseCase.Execute(participantInput);

            var bindParticipantInput = new BindParticipantInputBoundary
            {
                BarbecueIdentifier = Guid.Parse(barbecueOutput.GetIdentifier()),
                ParticipantIdentifier = participantOutput.ParticipantIdentifier
            };

            // Act
            bindParticipant.Execute(bindParticipantInput);

            var participant = barbecueRepository.Get(Guid.Parse(barbecueOutput.GetIdentifier()));

            // Assert
            Assert.IsNotNull(participant);
            Assert.Contains(participantOutput.ParticipantIdentifier, participant.Participants);
        }
    }
}
