using TrincaBarbecue.Application.UseCase.BindParticipant;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class BindParticipantTobarbecueController
    {
        private BindParticipantUseCase _bindParticipantUseCase;
        public BindParticipantTobarbecueController(BindParticipantUseCase bindParticipantUseCase)
        {
            _bindParticipantUseCase = bindParticipantUseCase;
        }

        public void Handle(BindParticipantInputBoundary input)
        {
            _bindParticipantUseCase.Execute(input);
        }
    }
}
