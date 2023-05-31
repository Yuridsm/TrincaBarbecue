using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class GetbarbecueByIdController
    {
        private readonly GetBarbecueByIdUseCase _getBarbecueByIdUseCase;

        public GetbarbecueByIdController(GetBarbecueByIdUseCase getBarbecueByIdUseCase)
        {
            _getBarbecueByIdUseCase = getBarbecueByIdUseCase;
        }

        public GetBarbecueByIdOutputBoundary Handle(GetBarbecueByIdInputBoundary input)
        {
            return _getBarbecueByIdUseCase.Execute(input);
        }
    }
}
