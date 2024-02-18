using SummitPro.Core.Aggregate.Basket;

namespace SummitPro.Application.Feature.CreateBasket;

public class CreateBasketUseCase : ICreateBasketInputBoundary
{
    private readonly ICreateBasketOutputBoundary _output;

    public CreateBasketUseCase(ICreateBasketOutputBoundary output)
    {
        _output = output;
    }

    public void Execute(CreateBasketInputData createBasketInputData)
    {
        // Criar instância e persistir na base de dados.
        // Também é interessante verificar a sua existência na base de dados.

        bool entityexistsInDatabase = false; // Simulation

        if (entityexistsInDatabase) return;

        var basket = new Basket(createBasketInputData.Name);

        Console.WriteLine($"Create Basket with Name = {createBasketInputData.Name} & Description = {createBasketInputData.Description}");

        var output = new CreateBasketOutputData(basket.Identifier, basket.Description);
        
        _output.CreateBasketSucceeded(output);
    }
}