using TrincaBarbecue.Application.UseCase.AddParticipante;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class AddParticipantController
    {
        private readonly AddParticipantUseCase _addParticipantUseCase;

        public AddParticipantController(AddParticipantUseCase addParticipantUseCase)
        {
            _addParticipantUseCase = addParticipantUseCase;
        }

        public AddParticipantOutputBoundary Handle(AddParticipantInputBoundary input)
        {
            return _addParticipantUseCase.Execute(input);
        }
    }
}
