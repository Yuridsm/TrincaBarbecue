using NUnit.Framework;
using TrincaBarbecue.Application.Input;
using TrincaBarbecue.Application.UseCase;
using TrincaBarbecue.Core.DomainException;
using TrincaBarbecue.Infrastructure.Repository;

namespace TrincaBarbecue.Test.Integration
{
    public class AddNewBarbecueTest
    {
        [Test]
        public void ShouldAddNewBarbecue()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory();
            var barbecue = new AddNewBarbecueUseCase(barbecueRepository);
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
        public void NotShouldAddNewBarbecue_WhetherDateTimeDoesNotMatchWithNow()
        {
            // Arrange
            var barbecueRepository = new BarbecueRepositoryInMemory();
            var barbecue = new AddNewBarbecueUseCase(barbecueRepository);
            var additional = new List<string>
            {
                "Description 001",
                "Description 002",
                "Description 003",
            };

            var input = BarbecueInput.FactoryMethod("Description 01", additional, DateTime.Parse("26/05/2025 05:42:00 -3:00"), DateTime.Parse("26/05/2023 05:42:00 -3:00"));

            // Act
            

            // Act & Assert
            Assert.Throws<DateDoesNotMatchException>(() =>
            {
                var identifier = barbecue.Execute(input);
            });
        }
    }
}
