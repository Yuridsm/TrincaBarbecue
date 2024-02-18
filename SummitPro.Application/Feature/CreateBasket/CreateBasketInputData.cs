namespace SummitPro.Application.Feature.CreateBasket;

public class CreateBasketInputData
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public CreateBasketInputData(string name, string description)
    {
        Name = name;
        Description = description;
    }
}