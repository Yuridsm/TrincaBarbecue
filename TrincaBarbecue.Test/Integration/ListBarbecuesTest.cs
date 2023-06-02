using AutoMapper;
using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.AddParticipante;
using TrincaBarbecue.Application.UseCase.BindParticipant;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.ListBarbecues;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Test.Integration
{
    [TestFixture]
    public class ListBarbecuesTest
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
        public void ShouldListAllExistingBarbecues()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var participantRepository = new ParticipantRepositoryInMemory(_mapper);
            var barbecueUseCase = new CreateBarbecueUseCase(barbecueRepository);
            var participantUseCase = new AddParticipantUseCase(barbecueRepository, participantRepository);
            var bindParticipant = new BindParticipantUseCase(barbecueRepository, participantRepository);
            var listBarbecues = new ListBarbecuesUseCase(barbecueRepository, participantRepository);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",

            };
            var barbecueInput = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
            var barbecueOutput = barbecueUseCase.Execute(barbecueInput);

            var items = new List<string>
            {
                "Item 01",
                "Item 02",
                "Item 03"
            };

            var participantInput = new AddParticipantInputBoundary("Yuri Melo", "@yuridsm", 100.00f, false, Guid.Parse(barbecueOutput.GetIdentifier()), items);

            var participantOutput = participantUseCase.Execute(participantInput);

            var bindParticipantInput = new BindParticipantInputBoundary
            {
                BarbecueIdentifier = Guid.Parse(barbecueOutput.GetIdentifier()),
                ParticipantIdentifier = participantOutput.ParticipantIdentifier
            };

            // Act
            bindParticipant.Execute(bindParticipantInput);

            var output = listBarbecues.Execute();

            // Assert
            Assert.IsNotNull(output);
        }
    }
}
