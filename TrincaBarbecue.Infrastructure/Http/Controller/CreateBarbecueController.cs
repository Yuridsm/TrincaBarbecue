using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class CreateBarbecueController
    {
        private readonly CreateBarbecueUseCase _createBarbecueUseCase;

        public CreateBarbecueController(CreateBarbecueUseCase createBarbecueUseCase)
        {
            _createBarbecueUseCase = createBarbecueUseCase;
        }

        public CreateBarbecueController SetDistributedCache(ICachedRepository cachedRepository)
        {
            _createBarbecueUseCase
                .SetDistributedCache(cachedRepository);

            return this;
        }

        public CreateOutputBoundary Handle(CreateInputBoundary input)
        {
            return _createBarbecueUseCase.Execute(input);
        }
    }
}
