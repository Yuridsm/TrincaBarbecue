using TrincaBarbecue.Application.UseCase.CreateBarbecue;

namespace TrincaBarbecue.Infrastructure.Http.Controllers
{
    public sealed class CreateBarbecue
    {
        private readonly CreateBarbecueUseCase _useCase;

        public CreateBarbecue(CreateBarbecueUseCase useCase)
        {
            _useCase = useCase;
        }

        public string Handle(string description, string beginDateTime, string endDateTime)
        {
            var inputBoundary = InputBoundary
                .FactoryMethod(description,
                new List<string>(),
                DateTime.Parse(beginDateTime),
                DateTime.Parse(endDateTime));

            var outputBoundary = _useCase.Execute(inputBoundary);

            return outputBoundary.GetIdentifier();
        }
    }
}
