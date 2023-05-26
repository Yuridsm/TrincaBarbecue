using NUnit.Framework;
using TrincaBarbecue.Core.Entity;

namespace TrincaBarbecue.Test.Unit
{
    public class BarbecueTest
    {
        [Test]
        public void ShouldAddParticipants()
        {
            // Arrange
            var add = new List<string>
            {
                "bla bla bla 01",
                "bla bla bla 02",
                "bla bla bla 03",
                "bla bla bla 04",
                "bla bla bla 05"
            };

            var barbecue = Barbecue.FactoryMethod("Frinds from Work!", add, DateTime.Parse("23/12/2023 13:00:00 -3:00"), DateTime.Parse("23/12/2023 17:30:00 -3:00"));

            // Act
            barbecue
                .AddParticipant("Yuri Melo", 100.50f)
                .AddParticipant("Júlio Miguel", 110.50f)
                .AddParticipant("Beatriz Nunes", 120.50f)
                .AddParticipant("Fran Alves", 150.50f)
                .AddParticipant("Leonardo Gonçalves", 140.50f)
                .AddParticipant("Djavan Viana", 130.50f)
                .AddParticipant("Maria Betânia", 120.50f)
                .AddParticipant("Larissa Gome", 100.50f)
                .AddParticipant("Rosângela Gomes", 110.50f)
                .AddParticipant("José Ildo", 120.50f)
                .Build();

            // Assert
            Assert.That(barbecue.ParticipantsQuantity() == 10);
        }

        [Test]
        public void ShouldRemoveParticipanteByIdenifier()
        {
            // Arrange
            var add = new List<string>
            {
                "bla bla bla 01",
                "bla bla bla 02",
                "bla bla bla 03",
                "bla bla bla 04",
                "bla bla bla 05"
            };

            var barbecue = Barbecue.FactoryMethod("Frinds from Work!", add, DateTime.Parse("23/12/2023 13:00:00 -3:00"), DateTime.Parse("23/12/2023 17:30:00 -3:00"));

            // Act
            barbecue
                .AddParticipant("Júlio Miguel", 110.50f)
                .AddParticipant("Yuri Melo", 100.50f)
                .AddParticipant("Beatriz Nunes", 120.50f)
                .AddParticipant("Fran Alves", 150.50f)
                .AddParticipant("Leonardo Gonçalves", 140.50f)
                .AddParticipant("Djavan Viana", 130.50f)
                .AddParticipant("Maria Betânia", 120.50f)
                .AddParticipant("Larissa Gome", 100.50f)
                .AddParticipant("Rosângela Gomes", 110.50f)
                .AddParticipant("José Ildo", 120.50f)
                .Build();

            var participant = barbecue.Participants.FirstOrDefault();
            var allIdentifier = barbecue.Participants.Select(o => o.Identifier);
            var participantExists = allIdentifier.Contains(participant.Identifier);
            barbecue.RemoveParticipant(participant.Identifier);

            var participantNotExist = allIdentifier.Contains(participant.Identifier);

            // Assert
            Assert.IsTrue(participantExists);
            Assert.IsFalse(participantNotExist);
        }
    }
}
