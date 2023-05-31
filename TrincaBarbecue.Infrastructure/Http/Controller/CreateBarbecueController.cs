using TrincaBarbecue.Application.UseCase.CreateBarbecue;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class CreateBarbecueController
    {
        private readonly CreateBarbecueUseCase _createBarbecueUseCase;

        public CreateBarbecueController(CreateBarbecueUseCase createBarbecueUseCase)
        {
            _createBarbecueUseCase = createBarbecueUseCase;
        }

        public CreateOutputBoundary Handle(CreateInputBoundary input)
        {
            return _createBarbecueUseCase.Execute(input);
        }
    }
}
