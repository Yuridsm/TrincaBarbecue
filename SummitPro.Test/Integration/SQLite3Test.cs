using NUnit.Framework;
using SummitPro.Infrastructure.SQLite3Testing;

namespace SummitPro.Test.Integration;

[TestFixture]
public class SQLite3Test
{
    [Test]
    public async Task TestSQLite3()
    {
        var foo = await UseCaseSQLite3Test.Execute();
        Assert.IsNotNull(foo);
    }
}
