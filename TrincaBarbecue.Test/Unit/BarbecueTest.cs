using NUnit.Framework;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.Core.Aggregate.Participant;

namespace TrincaBarbecue.Test.Unit
{
    public class BarbecueTest
    {
        [Test]
        public void ShouldAddParticipantsWithContributionSugestion()
        {
            // Arrange
            var add = new List<string>
            {
                "Chegue no horário",
                "Beba conciente",
                "Pode dançar a vontade, viu?!"
            };

            var barbecue = Barbecue.FactoryMethod("Friends from Work!", add, DateTime.Parse("23/12/2023 13:00:00 -3:00"), DateTime.Parse("23/12/2023 17:30:00 -3:00"));

            var participant01 = Participant.FactoryMethod("Yuri Melo", "@yuridsm", 100.50f);
            var participant02 = Participant.FactoryMethod("Júlio Miguel", "@ojuliomiguel", 110.50f);
            var participant03 = Participant.FactoryMethod("Beatriz Nunes", "@beatriz", 120.50f);

            // Act
            barbecue
                .AddParticipant(participant01.Identifier)
                .AddParticipant(participant02.Identifier)
                .AddParticipant(participant03.Identifier)
                .AddAdditionalRemark("Mais uma informação importante para o evento.")
                .AddDescription("Atualização da descrição do Churras da Trinca!! Não perca!!!")
                .Build();

            // Assert
            Assert.That(barbecue.ParticipantsQuantity() == 3);
        }

        [Test]
        public void ShouldAddParticipantsWithoutContributionSugestion()
        {
            // Arrange
            var add = new List<string>
            {
                "bla bla bla 01",
                "bla bla bla 02"
            };

            var barbecue = Barbecue.FactoryMethod("Frinds from Work!", add, DateTime.Parse("23/12/2023 13:00:00 -3:00"), DateTime.Parse("23/12/2023 17:30:00 -3:00"));

            var participant = Participant.FactoryMethod("Yuri Melo", "@yuridsm", 100.50f);

            // Act
            barbecue
                .AddParticipant(participant.Identifier)
                .Build();

            // Assert
            Assert.That(barbecue.ParticipantsQuantity() == 1);
        }

        [Test]
        public void ShouldRescheduleBarbecue()
        {
            // Arrange
            var add = new List<string>
            {
                "bla bla bla 01",
                "bla bla bla 02"
            };

            var participant = Participant.FactoryMethod("Yuri Melo", "@yuridsm", 100.50f);

            var barbecue = Barbecue.FactoryMethod("Frinds from Work!", add, DateTime.Parse("23/12/2023 13:00:00 -3:00"), DateTime.Parse("23/12/2023 17:30:00 -3:00"));

            barbecue
                .AddParticipant(participant.Identifier)
                .Build();

            // Act
            barbecue.Reschedule(DateTime.Parse("27/12/2023 13:00:00 -3:00"), DateTime.Parse("27/12/2023 13:00:00 -3:00"));

            // Assert
            Assert.That(barbecue.ParticipantsQuantity() == 1);
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

            var participant01 = Participant.FactoryMethod("Yuri Melo", "@yuridsm", 100.50f);
            var participant02 = Participant.FactoryMethod("Júlio Miguel", "@ojuliomiguel", 110.50f);
            var participant03 = Participant.FactoryMethod("Beatriz Nunes", "@beatriz", 120.50f);

            // Act
            barbecue
                .AddParticipant(participant01.Identifier)
                .AddParticipant(participant02.Identifier)
                .AddParticipant(participant03.Identifier)
                .Build();

            var allIdentifiers = barbecue
                .Participants
                .Select(o => o);

            var participantIdentifier = participant01.Identifier;
            var participantExists = allIdentifiers.Contains(participantIdentifier);

            barbecue.RemoveParticipant(participantIdentifier);

            var participantNotExist = allIdentifiers.Contains(participantIdentifier);

            // Assert
            Assert.IsTrue(participantExists);
            Assert.IsFalse(participantNotExist);
        }
    }
}
