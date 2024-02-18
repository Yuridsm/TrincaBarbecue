using NUnit.Framework;
using SummitPro.Application.Feature.AddItemInBasket;
using SummitPro.Core.Aggregate.Basket;

namespace SummitPro.Test.Feature;

[TestFixture]
public class AddItemInBasketTestUnit
{
    [Test]
    public void FooTest()
    {
        // Create a Basket
        var basket = new Basket("BasketBR");
        
        // Create an Item and Added to basket
        var item = new Item("ItemBR", "This is some Item");

        basket.AddItem(item);

        var input = new AddItemInBasketInputData(basket.Identifier, item.Name, item.Description);

        // Test the Use Case
        new AddItemInBaskteUseCase().Create(input);
    }
}