using SummitPro.Application.UseCase.GetParticipant;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface
{
    public abstract class IGetParticipantByIdUseCase : IUseCaseAsynchronous
        .WithInputBoundary<GetParticipantByIdInputBoundary>
        .WithOutputBoundary<GetParticipantByIdOutputBoundary>
    {
        private ICachedRepository _cachedRepository = null!;

        public IGetParticipantByIdUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }
    }
}
