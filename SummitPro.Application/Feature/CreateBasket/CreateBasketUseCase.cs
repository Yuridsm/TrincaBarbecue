namespace SummitPro.Application.Feature.CreateBasket;

public class CreateBasketUseCase : ICreateBasketInputBoundary
{
    public void Execute(CreateBasketInputData createBasketInputData)
    {
        Console.WriteLine($"Create Basket with Name = {createBasketInputData.Name} & Description = {createBasketInputData.Description}");
    }
}