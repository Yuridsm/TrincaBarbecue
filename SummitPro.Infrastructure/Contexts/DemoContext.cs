using Microsoft.EntityFrameworkCore;

namespace SummitPro.Infrastructure.Contexts;

public class DemoContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public string DbPath { get; }

    public DemoContext()
    {
        DbPath = "Blogs.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Blog>()
            .HasKey(o => o.Id);
    }
}