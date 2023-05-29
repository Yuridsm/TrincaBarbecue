using NUnit.Framework;
using TrincaBarbecue.Core.Aggregate.Participant;

namespace TrincaBarbecue.Test.Unit
{
    public class ParticipantTest
    {
        [Test]
        public void ShouldCreateParticipantWithContributionSugestion()
        {
            // Arrange
            var participant = Participant.FactoryMethod("Iran Melo", "@irandsm", 100.50f);
            
            // Act & Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.ContributionValue.Value, Is.AtLeast(0));
            Assert.That(participant.ContributionValue.Value, Is.EqualTo(100.50f));
        }

        [Test]
        public void ShouldCreateParticipantWithoutContributionSugestion()
        {
            // Arrange
            var participant = Participant.FactoryMethod("Pedro Palermo", "@pedro");

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
            var participant1 = Participant.FactoryMethod("Pedro Palermo", "@pedro", true);
            var participant2 = Participant.FactoryMethod("Pedro Palermo", "@pedro");

            participant2.AddBringDrink(true);
            
            // Act & Assert
            Assert.That(participant1, Is.Not.Null);
            Assert.That(participant1.ContributionValue.Value, Is.AtLeast(0));
            Assert.That(participant1.ContributionValue.Value, Is.EqualTo(0.0f));
            Assert.That(participant1.BringDrink, Is.EqualTo(true));

            Assert.That(participant2, Is.Not.Null);
            Assert.That(participant2.ContributionValue.Value, Is.AtLeast(0));
            Assert.That(participant2.ContributionValue.Value, Is.EqualTo(0.0f));
            Assert.That(participant2.BringDrink, Is.EqualTo(true));
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
                .FactoryMethod("Isadora Oliveira", "@isadora")
                .AddItem(bebida)
                .AddItems(items)
                .AddBringDrink(true);

            // Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.BringDrink, Is.EqualTo(true));
            Assert.That(participant.Items.Count(), Is.EqualTo(6));
        }

        [Test]
        public void ShouldHaveJustOneParticipantWithSameUsername()
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
                .FactoryMethod("Isadora Oliveira", "@isadora", true)
                .AddItem(bebida)
                .AddItems(items);

            // Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.BringDrink, Is.EqualTo(true));
            Assert.That(participant.Items.Count(), Is.EqualTo(6));
            Assert.That(participant.Username.Value, Is.EqualTo("@isadora"));
        }

        [Test]
        public void ShouldUpdateUsername()
        {
            // Arrange
            var participant = Participant.FactoryMethod("Iran Melo", "@irandsm", 100.50f);

            // Act
            participant.UpdateUsername("@iranmelo");

            // Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.ContributionValue.Value, Is.AtLeast(0));
            Assert.That(participant.ContributionValue.Value, Is.EqualTo(100.50f));
            Assert.That(participant.Username.Value, Is.EqualTo("@iranmelo"));
        }

        [Test]
        public void ShouldBuildParticipant()
        {
            // Arrange
            var participant = Participant
                .FactoryMethod("Iran Melo", "@irandsm", 100.50f)
                .AddItem("Refriiii")
                .AddBringDrink(true)
                .UpdateUsername("@iranmelo")
                .Build();

            // Act & Assert
            Assert.That(participant, Is.Not.Null);
            Assert.That(participant.ContributionValue.Value, Is.EqualTo(100.50f));
            Assert.That(participant.Username.Value, Is.EqualTo("@iranmelo"));
            Assert.That(participant.BringDrink, Is.EqualTo(true));
        }
    }
}
