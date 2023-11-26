namespace SummitPro.Core.Aggregate.Basket;

public class Item
{
    public Guid Identifier { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    public Item(string name, string description)
    {
        Identifier = Guid.NewGuid();
        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}
