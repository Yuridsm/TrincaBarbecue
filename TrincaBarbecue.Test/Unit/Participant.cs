using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaBarbecue.Application.Input;
using TrincaBarbecue.Application.UseCase;
using TrincaBarbecue.Infrastructure.Repository;

namespace TrincaBarbecue.Test.Unit
{
    public class Participant
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

            var input = BarbecueInput.FactoryMethod("Churras", additional, DateTime.Parse("26/05/2025 01:00:00 -3:00"), DateTime.Parse("26/05/2025 05:42:00 -3:00"));

            // Act
            var identifier = barbecue.Execute(input);
            var instance = barbecueRepository.Get(identifier);

            // Assert
            Assert.That(identifier, Is.EqualTo(instance.Identifier));
        }
    }
}
