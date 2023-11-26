namespace SummitPro.Presenter;

public class CreateBasketView
{
    public string Description { get; set; }
    public string Message { get; set; }
    public string ErrorMessage { get; set; }

    private CreateBasketView(string message, string errorMessage, string description)
    {
        Message = message;
        ErrorMessage = errorMessage;
        Description = description;
    }

    public static CreateBasketView Success(string message, string description)
    {
        return new CreateBasketView(message, string.Empty, description);
    }

    public static CreateBasketView Failure(string errorMessage, string description)
    {
        return new CreateBasketView(string.Empty, errorMessage, description);
    }
}