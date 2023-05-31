using AutoMapper;
using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Test.Integration
{
    [TestFixture]
    public class GetByIdBarbecueTest
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
        public void GetBarbecueById()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var createBarbecue = new CreateBarbecueUseCase(barbecueRepository);
            var barbecue = new GetBarbecueByIdUseCase(barbecueRepository);

            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };
            var barbacueInstance = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            var insertedbarbecue = createBarbecue.Execute(barbacueInstance);

            var input = new GetBarbecueByIdInputBoundary
            {
                BarbecueIdentifier = Guid.Parse(insertedbarbecue.GetIdentifier())
            };

            // Act
            GetBarbecueByIdOutputBoundary output = barbecue.Execute(input);

            // Assert
            Assert.That(insertedbarbecue.GetIdentifier(), Is.EqualTo(output.BarbecueIdentifier.ToString()));
        }
    }
}
