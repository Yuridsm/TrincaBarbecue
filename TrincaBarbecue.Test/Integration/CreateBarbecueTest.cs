using NUnit.Framework;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Core.DomainException;
using TrincaBarbecue.Infrastructure.Repository;

namespace TrincaBarbecue.Test.Integration
{
    public class CreateBarbecueTest
    {
        [Test]
        public void ShouldCreateBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory();
            var barbecue = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };
            
            var input = InputBoundary.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var output = barbecue.Execute(input);
            var sanitizedData = Guid.Parse(output.GetIdentifier());
            var instance = barbecueRepository.Get(sanitizedData);

            // Assert
            Assert.That(output.GetIdentifier(), Is.EqualTo(instance?.Identifier.ToString()));
        }

        [Test]
        public void ShouldThrowException_WhetherDateTimeDoesNotMatchWithNow()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory();
            var barbecue = new CreateBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = InputBoundary.FactoryMethod("Trinca Churras", additional, DateTime.Parse("26/05/2025 05:42:00 -3:00"), DateTime.Parse("26/05/2023 05:42:00 -3:00"));

            // Act & Assert
            Assert.Throws<DateTimeDoesNotMatchException>(() =>
            {
                var identifier = barbecue.Execute(input);
            });
        }
    }
}
