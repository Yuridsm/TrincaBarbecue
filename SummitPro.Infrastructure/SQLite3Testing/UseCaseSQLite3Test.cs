using Microsoft.EntityFrameworkCore;
using SummitPro.Infrastructure.Contexts;

namespace SummitPro.Infrastructure.SQLite3Testing;

public class UseCaseSQLite3Test
{
    public static async Task<IEnumerable<Blog>> Execute()
    {
        await using var db = new DemoContext();

        Console.WriteLine($"Database path: {db.DbPath}");

        db.Blogs.Add(new Blog { Id = 1, Name = "Yuri Melo", CreatedTimestamp = DateTime.Now });
        db.Blogs.Add(new Blog { Id = 2, Name = "Igor Melo", CreatedTimestamp = DateTime.Now });

        await db.SaveChangesAsync();

        Console.WriteLine($"Querying for barbecues");
        var results = 
            from blog in db.Blogs
            select blog;

        await foreach (var s in results.AsAsyncEnumerable())
            Console.WriteLine($"Desciption: {s.Name}");

        if (results is not null) return results;

        return Enumerable.Empty<Blog>();
    }
}
