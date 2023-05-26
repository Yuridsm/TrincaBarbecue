using NUnit.Framework;
using TrincaBarbecue.Core.Entity;

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

    //안녕
    [Test]
    public void ShoullValidateUnicodeCaracter()
    {
        // Arrange & Act
        var validatedName = Name.Validate("안녕");

        // Assert
        Assert.False(validatedName);
    }
}