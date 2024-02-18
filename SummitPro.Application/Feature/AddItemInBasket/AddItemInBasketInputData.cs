namespace SummitPro.Application.Feature.AddItemInBasket;

public class AddItemInBasketInputData
{
    public Guid BasketId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public AddItemInBasketInputData(Guid basketId, string name, string description)
    {
        BasketId = basketId;
        Name = name;
        Description = description;
    }
}