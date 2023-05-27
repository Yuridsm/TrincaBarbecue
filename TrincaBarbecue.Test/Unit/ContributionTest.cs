using NUnit.Framework;
using TrincaBarbecue.Core.DomainException;
using TrincaBarbecue.Core.Aggregate;

namespace TrincaBarbecue.Test.Unit
{
    public class ContributionTest
    {
        //InvalidContributionException
        [Test]
        public void ShouldThrowException_WhetherContributionSugestionIsLessThenZero()
        {
            // Arrange
            string name = "Yuri Melo";
            double contributionSugestion = -100.0f;

            // Act & Assert
            Assert.Throws<InvalidContributionException>(() => Participant.FactoryMethod(name, contributionSugestion));
        }
    }
}
