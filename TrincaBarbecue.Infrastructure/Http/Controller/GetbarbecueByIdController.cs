using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Application.UseCase.GetParticipant;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class GetbarbecueByIdController
    {
        private readonly GetBarbecueByIdUseCase _getBarbecueByIdUseCase;
        private readonly GetParticipantsUseCase _getParticipantsUseCase;

        public GetbarbecueByIdController(
            GetBarbecueByIdUseCase getBarbecueByIdUseCase,
            GetParticipantsUseCase getParticipantsUseCase
            )
        {
            _getBarbecueByIdUseCase = getBarbecueByIdUseCase;
            _getParticipantsUseCase = getParticipantsUseCase;
        }

        public GetBarbecueByIdOutputBoundary Handle(GetBarbecueByIdInputBoundary input)
        {
            var barbecue = _getBarbecueByIdUseCase.Execute(input);

            if (barbecue == null) throw new ArgumentNullException("There is no barbecue.");

            var result = _getParticipantsUseCase.Execute(new GetParticipantsInputBoundary
            {
                ParticipantIdentifiers = barbecue.Participants
            });

            barbecue.Participants = result.Participants.Select(o => o.Identifier);

            return barbecue;
        }
    }
}
