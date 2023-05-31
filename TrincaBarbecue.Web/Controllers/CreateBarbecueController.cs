using TrincaBarbecue.Application.UseCase.CreateBarbecue;

namespace TrincaBarbecue.Web.Controllers
{
    public sealed class CreateBarbecueController
    {
        private readonly CreateBarbecueUseCase _useCase;

        public CreateBarbecueController(CreateBarbecueUseCase useCase)
        {
            _useCase = useCase;
        }

        public string Handle(string description, string beginDateTime, string endDateTime)
        {
            var inputBoundary = CreateInputBoundary
                .FactoryMethod(description,
                new List<string>(),
                DateTime.Parse(beginDateTime),
                DateTime.Parse(endDateTime));

            var outputBoundary = _useCase.Execute(inputBoundary);

            return outputBoundary.GetIdentifier();
        }
    }
}
