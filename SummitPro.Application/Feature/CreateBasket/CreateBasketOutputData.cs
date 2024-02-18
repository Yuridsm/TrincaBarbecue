namespace SummitPro.Application.Feature.CreateBasket;

public class CreateBasketOutputData
{
    public Guid Identifier { get; private set; }
    public string Description { get; private set; }

    public CreateBasketOutputData(Guid identifier, string description)
    {
        Identifier = identifier;
        Description = description;
    }
}