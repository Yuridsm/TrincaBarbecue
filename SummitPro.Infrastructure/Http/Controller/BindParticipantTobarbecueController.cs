using SummitPro.Application.UseCase.BindParticipant;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Infrastructure.Http.Controller
{
    public class BindParticipantTobarbecueController
    {
        private BindParticipantUseCase _bindParticipantUseCase;
        public BindParticipantTobarbecueController(BindParticipantUseCase bindParticipantUseCase)
        {
            _bindParticipantUseCase = bindParticipantUseCase;
        }

        public BindParticipantTobarbecueController SetDistributedCache(ICachedRepository cachedRepository)
        {
            _bindParticipantUseCase
                .SetDistributedCache(cachedRepository);

            return this;
        }

        public void Handle(BindParticipantInputBoundary input)
        {
            _bindParticipantUseCase.Execute(input);
        }
    }
}
