using SummitPro.SharedKernel;

namespace SummitPro.Core.Aggregate.Basket.Events;

public class AddedItemEvent : DomainEventBase
{
    public Guid ItemId { get; private set; }
    public string Description { get; private set; } = string.Empty;

    public AddedItemEvent(Guid itemId, string description)
    {
        ItemId = itemId;
        Description = description;
    }
}