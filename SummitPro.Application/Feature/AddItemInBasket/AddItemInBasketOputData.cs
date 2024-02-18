using SummitPro.Core.Aggregate.Basket;

namespace SummitPro.Application.Feature.AddItemInBasket;

public class AddItemInBasketOutputData
{
    public Guid ItemId { get; private set; }

    public AddItemInBasketOutputData(Guid itemId)
    {
        ItemId = itemId;
    }
}