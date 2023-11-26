namespace SummitPro.Presenter;

public class CreateBasketViewModel
{
    public string Description { get; set; }
    public string Message { get; set; }
    public string ErrorMessage { get; set; }

    private CreateBasketViewModel(string message, string errorMessage, string description)
    {
        Message = message;
        ErrorMessage = errorMessage;
        Description = description;
    }

    public static CreateBasketViewModel Success(string message, string description)
    {
        return new CreateBasketViewModel(message, string.Empty, description);
    }

    public static CreateBasketViewModel Failure(string errorMessage, string description)
    {
        return new CreateBasketViewModel(string.Empty, errorMessage, description);
    }
}