using Ardalis.Specification;
using SummitPro.Core.Aggregate.Basket;

namespace SummitPro.Core.Specification;

public class MaxItemsInBasketSpecification : Specification<Basket>
{
    public MaxItemsInBasketSpecification(int maxItemInBasket)
    {
        Query.Where(o => o.Items.Count == maxItemInBasket);
    }
}