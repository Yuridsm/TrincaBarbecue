using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Infrastructure.Http.Controller
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

        public async Task<CreateBarbecueOutputBoundary> Handle(CreateBarbecueInputBoundary input)
        {
            var output = await _createBarbecueUseCase.Execute(input);

            return output;
        }
    }
}
