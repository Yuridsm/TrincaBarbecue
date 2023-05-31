using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.BindParticipant
{
    public class BindParticipantUseCase : IUseCaseSinchronous
        .WithInputBoundary<BindParticipantInputBoundary>
        .WithoutOutputBoundary
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;

        public BindParticipantUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public override void Execute(BindParticipantInputBoundary inputBoundary)
        {
            if (inputBoundary == null) throw new ArgumentNullException("Input can not be empty.");

            var barbecue = _barbecueRepository.Get(inputBoundary.BarbecueIdentifier);

            if (barbecue == null) throw new ArgumentNullException("Barbecue does not exist.");

            if (barbecue.Participants.Contains(inputBoundary.ParticipantIdentifier)) return;

            var participant = _participantRepository.Get(inputBoundary.ParticipantIdentifier);

            if (participant == null) throw new ArgumentNullException("Participant does not exist.");

            barbecue.AddParticipant(inputBoundary.ParticipantIdentifier);

            _barbecueRepository.Update(barbecue);
        }
    }
}
