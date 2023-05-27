using NUnit.Framework;
using TrincaBarbecue.Application.Input;
using TrincaBarbecue.Application.UseCase;
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
            
            var input = BarbecueInput.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var identifier = barbecue.Execute(input);
            var instance = barbecueRepository.Get(identifier);

            // Assert
            Assert.That(identifier, Is.EqualTo(instance.Identifier));
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

            var input = BarbecueInput.FactoryMethod("Trinca Churras", additional, DateTime.Parse("26/05/2025 05:42:00 -3:00"), DateTime.Parse("26/05/2023 05:42:00 -3:00"));

            // Act & Assert
            Assert.Throws<DateTimeDoesNotMatchException>(() =>
            {
                var identifier = barbecue.Execute(input);
            });
        }
    }
}
