using SummitPro.Core.Aggregate.Basket.Events;
using SummitPro.SharedKernel;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Core.Aggregate.Basket;

public class Basket : IEntity<Guid>, IAggregateRoot
{
	public Guid Identifier { get; private set; }
    private List<Item> _items = new();
    public IReadOnlyList<Item> Items => _items.AsReadOnly();
    public List<DomainEventBase> DomainEvents = new();

    public void AddItem(Item item)
    {
        if (_items.Contains(item)) return;

        _items.Add(item);
        
        DomainEvents.Add(new AddedItemEvent(Identifier, "Description to this Item"));
    }
}
