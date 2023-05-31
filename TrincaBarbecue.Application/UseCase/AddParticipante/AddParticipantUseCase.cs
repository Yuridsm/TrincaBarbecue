using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.Core.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.AddParticipante
{
    public class AddParticipantUseCase : IUseCaseSinchronous
        .WithInputBoundary<AddParticipantInputBoundary>
        .WithoutOutputBoundary
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;

        public AddParticipantUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public override void Execute(AddParticipantInputBoundary inputBoundary)
        {
            var barbecue = _barbecueRepository.Get(inputBoundary.BarbecueIdentifier);

            if (barbecue == null) throw new ArgumentException("There is no barbecue signed."); 

            var participant = Participant
                .FactoryMethod(
                    inputBoundary.Name,
                    inputBoundary.Username,
                    inputBoundary.SuggestionContribution);

            _participantRepository.Add(participant);

            barbecue.AddParticipant(participant.Identifier);


        }
    }
}
