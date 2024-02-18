using SummitPro.Core.Aggregate.Basket.Events;
using SummitPro.SharedKernel;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Core.Aggregate.Basket;

public class Basket : IEntity<Guid>, IAggregateRoot
{
	public Guid Identifier { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    private List<Item> _items = new();
    public IReadOnlyList<Item> Items => _items.AsReadOnly();
    public List<DomainEventBase> DomainEvents = new();

    private Basket(Guid identifier, string name, string description)
    {
        Identifier = identifier;
        Name = name;
        Description = description;
    }

    public Basket(string name)
    {
        Identifier = Guid.NewGuid();
        Name = name;
    }

    public static Basket Create(Guid identifier, string name, string description)
        => new Basket(identifier, name, description);

    public void AddItem(Item item)
    {
        if (_items.Contains(item)) return;

        _items.Add(item);
        
        DomainEvents.Add(new AddedItemEvent(Identifier, "Description to this Item"));
    }
}
