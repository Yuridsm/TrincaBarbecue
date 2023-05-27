using NUnit.Framework;
using TrincaBarbecue.Core.Aggregate;

namespace TrincaBarbecue.Test.Unit
{
    public class ParticipantTest
    {
        [Test]
        public void ShouldCreateParticipantWithContributionSugestion()
        {
            // Arrange
            var participant = Participant.FactoryMethod("Iran Melo", 100.50f);
            
            // Act & Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.ContributionValue.Value, Is.AtLeast(0));
            Assert.That(participant.ContributionValue.Value, Is.EqualTo(100.50f));
        }

        [Test]
        public void ShouldCreateParticipantWithoutContributionSugestion()
        {
            // Arrange
            var participant = Participant.FactoryMethod("Pedro Palermo");

            // Act & Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.ContributionValue.Value, Is.AtLeast(0));
            Assert.That(participant.ContributionValue.Value, Is.EqualTo(0.0f));
            Assert.That(participant.BringDrink, Is.EqualTo(false));
        }

        [Test]
        public void ShouldCreateParticipantThatBringDrink()
        {
            // Arrange
            var participant = Participant.FactoryMethod("Pedro Palermo", true);

            // Act & Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.ContributionValue.Value, Is.AtLeast(0));
            Assert.That(participant.ContributionValue.Value, Is.EqualTo(0.0f));
            Assert.That(participant.BringDrink, Is.EqualTo(true));
        }

        [Test]
        public void ShouldAddItemOrItems()
        {
            // Arrange
            string bebida = "Refrigerante Zero";
            var items = new List<string>
            {
                "Refrigerante Fanta",
                "Suco",
                "Água com gás",
                "Água sem gás",
                "Alguma bebida alcoólica"
            };

            // Act
            var participant = Participant
                .FactoryMethod("Isadora Oliveira", true)
                .AddItem(bebida)
                .AddItems(items);

            // Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.BringDrink, Is.EqualTo(true));
            Assert.That(participant.Items.Count(), Is.EqualTo(6));
        }
    }
}
