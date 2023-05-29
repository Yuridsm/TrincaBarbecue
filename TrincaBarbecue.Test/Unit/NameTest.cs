using NUnit.Framework;
using TrincaBarbecue.Core.Aggregate.Participant;

namespace TrincaBarbecue.Test.Unit;

public class NameTest
{
    [Test]
    public void ShoullValidateFullName()
    {
        // Arrange & Act
        var validatedName = Name.Validate("Yuri Melo");

        // Assert
        Assert.True(validatedName);
    }
}