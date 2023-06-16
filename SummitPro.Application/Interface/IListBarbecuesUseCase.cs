using SummitPro.Application.UseCase.ListBarbecues;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface
{
    public abstract class IListBarbecuesUseCase : IUseCaseAsynchronous
        .WithoutInputBoundary
        .WithOutputBondary<ListBarbecuesOutputBoundary>
    {
        protected ICachedRepository _cachedRepository;

        public IListBarbecuesUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }
    }
}
