using AutoMapper;
using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.GetParticipant;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Test.Integration
{
    [TestFixture]
    public class GetParticipantsTest
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
        public void ShouldGetParticipants()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var participantRepository = new ParticipantRepositoryInMemory(_mapper);

            var barbecueUseCase = new CreateBarbecueUseCase(barbecueRepository);
            var participantUseCase = new AddParticipantUseCase(barbecueRepository, participantRepository);

            var getParticipantsUseCase = new GetParticipantsUseCase(participantRepository);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003"
            };

            var barbecueInput = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
            var barbecueOutput = barbecueUseCase.Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var participantInput = new AddParticipantInputBoundary("Iran Melo", "@irandsm", 100.00f, false, Guid.Parse(barbecueOutput.GetIdentifier()), items);
            var participantOutput = participantUseCase.Execute(participantInput);

            // Act
            var getParticipants = getParticipantsUseCase.Execute(new GetParticipantsInputBoundary
            {
                ParticipantIdentifiers = new List<Guid> { participantOutput.ParticipantIdentifier }
            });

            var identifiers = getParticipants
                .Participants
                .Select(x => x.Identifier)
                .ToList();

            // Assert
            Assert.IsNotNull(getParticipants);
            Assert.Contains(participantOutput.ParticipantIdentifier , identifiers);
        }
    }
}
