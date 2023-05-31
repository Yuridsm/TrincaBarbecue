using AutoMapper;
using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.Core.DomainException;
using TrincaBarbecue.Infrastructure.RepositoryInMemory;
using TrincaBarbecue.Infrastructure.RepositoryInMemory.Models;

namespace TrincaBarbecue.Test.Integration
{
    [TestFixture]
    public class CreateBarbecueTest
    {
        private Mapper _mapper;

        [SetUp]
        public void SetUp()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<BarbecueModelMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [Test]
        public void ShouldCreateBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var barbecue = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };
            
            var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var output = barbecue.Execute(input);
            var sanitizedData = Guid.Parse(output.GetIdentifier());
            var instance = barbecueRepository.Get(sanitizedData);

            // Assert
            Assert.That(output.GetIdentifier(), Is.EqualTo(instance?.Identifier.ToString()));
        }

        [Test]
        public void ShouldUpdateBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var barbecue = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));
            
            var participant = Participant
                .FactoryMethod("Iran Melo", "@irandsm", 100.50f)
                .AddItem("Refriiii")
                .AddBringDrink(true)
                .UpdateUsername("@iranmelo")
                .Build();

            var output = barbecue.Execute(input);
            var sanitizedData = Guid.Parse(output.GetIdentifier());
            var instance = barbecueRepository.Get(sanitizedData);
            instance.AddAdditionalRemark("Outra Remark adicionado");
            
            // Act
            barbecueRepository.Update(instance);
            instance = barbecueRepository.Get(sanitizedData);

            // Assert
            Assert.That(output.GetIdentifier(), Is.EqualTo(instance?.Identifier.ToString()));
            Assert.That(instance.AdditionalRemarks.Count(), Is.EqualTo(4));
        }

        [Test]
        public void ShouldThrowException_WhetherDateTimeDoesNotMatchWithNow()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory(_mapper);
            var barbecue = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = CreateInputBoundary.FactoryMethod("Trinca Churras", additional, DateTime.Parse("26/05/2025 05:42:00 -3:00"), DateTime.Parse("26/05/2023 05:42:00 -3:00"));

            // Act & Assert
            Assert.Throws<DateTimeDoesNotMatchException>(() =>
            {
                var identifier = barbecue.Execute(input);
            });
        }
    }
}
