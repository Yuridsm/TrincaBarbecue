using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface
{
    public abstract class IBindParticipantUseCase : IUseCaseSinchronous
        .WithInputBoundary<BindParticipantInputBoundary>
        .WithoutOutputBoundary
    {
        protected ICachedRepository _cachedRepository;

        public IBindParticipantUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }
    }
}
