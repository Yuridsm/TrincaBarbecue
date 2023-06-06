using NUnit.Framework;
using SummitPro.SharedKernel.DomainException;
using SummitPro.Core.Aggregate.Participant;

namespace SummitPro.Test.Unit
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
