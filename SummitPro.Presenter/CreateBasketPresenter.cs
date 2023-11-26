using SummitPro.Application.Feature.CreateBasket;

namespace SummitPro.Presenter;

public class CreateBasketPresenter : ICreateBasketOutputBoundary
{
    private readonly ICreateBasketView _createBasketView;

    public CreateBasketPresenter(ICreateBasketView createBasketView)
    {
        _createBasketView = createBasketView;
    }

    public void CreateBasketSucceeded(CreateBasketOutputData createBasketOutputData)
    {
        var basket = CreateBasketView.Success(SuccessMessageFor(createBasketOutputData), createBasketOutputData.Description);

        _createBasketView.Render(basket);
    }

    private string SuccessMessageFor(CreateBasketOutputData createBasketOutputData) {
        return "Create Basket created with Id: " + createBasketOutputData.Identifier
                + " Description: " + createBasketOutputData.Description;
    }
}
