using SummitPro.Application.UseCase.GetBarbecueById;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface
{
    public abstract class IGetBarbecueByIdUseCase : IUseCaseAsynchronous
        .WithInputBoundary<GetBarbecueByIdInputBoundary>
        .WithOutputBoundary<GetBarbecueByIdOutputBoundary>
    {
        protected ICachedRepository _cachedRepository;

        public IGetBarbecueByIdUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }
    }
}
