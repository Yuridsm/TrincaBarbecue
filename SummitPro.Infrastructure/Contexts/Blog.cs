namespace SummitPro.Infrastructure.Contexts;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedTimestamp { get; set; }
}