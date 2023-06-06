using NUnit.Framework;
using SummitPro.Core.Aggregate.Participant;

namespace SummitPro.Test.Unit;

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