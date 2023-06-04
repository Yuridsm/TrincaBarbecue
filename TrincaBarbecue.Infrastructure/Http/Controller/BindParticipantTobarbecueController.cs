using TrincaBarbecue.Application.UseCase.BindParticipant;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.Http.Controller
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
