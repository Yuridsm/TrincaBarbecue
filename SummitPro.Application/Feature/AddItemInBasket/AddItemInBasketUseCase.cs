namespace SummitPro.Application.Feature.AddItemInBasket;

public class AddItemInBaskteUseCase : IAddItemInBasketInputBoundary
{
    public void Create(AddItemInBasketInputData input)
    {
        Console.WriteLine($"Add Item with Name {input.Name} in Basket with {input.BasketId}");
    }
}