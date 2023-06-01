using NUnit.Framework;
using TrincaBarbecue.SharedKernel.DomainException;
using TrincaBarbecue.Core.Aggregate.Participant;

namespace TrincaBarbecue.Test.Unit
{
    public class ContributionTest
    {
        [Test]
        public void ShouldThrowException_WhetherContributionSugestionIsLessThenZero()
        {
            // Arrange
            string name = "Yuri Melo";
            string username = "@yuridsm";
            double contributionSugestion = -100.0f;

            // Act & Assert
            Assert.Throws<InvalidContributionException>(() => Participant.FactoryMethod(name, username, contributionSugestion));
        }
    }
}
