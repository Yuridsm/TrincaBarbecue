using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.SharedKernel.Interfaces;
using TrincaBarbecue.SharedKernel.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.AddParticipante
{
    public class AddParticipantUseCase : IUseCaseSinchronous
        .WithInputBoundary<AddParticipantInputBoundary>
        .WithOutputBoundary<AddParticipantOutputBoundary>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;
        private ICachedRepository<Participant> _cachedRepository;

        public AddParticipantUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public AddParticipantUseCase SetDistributedCache(ICachedRepository<Participant> cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override AddParticipantOutputBoundary Execute(AddParticipantInputBoundary inputBoundary)
        {
            var barbecue = _barbecueRepository.Get(inputBoundary.BarbecueIdentifier);

            if (barbecue == null) throw new ArgumentException("There is no barbecue signed.");

            var participant = Participant
                .FactoryMethod(
                    inputBoundary.Name,
                    inputBoundary.Username,
                    inputBoundary.SuggestionContribution);

            participant.AddItems(inputBoundary.Items);

            _participantRepository.Add(participant);

            if (_cachedRepository != null) _cachedRepository.Set(inputBoundary.BarbecueIdentifier.ToString(), participant);

            return new AddParticipantOutputBoundary { ParticipantIdentifier = participant.Identifier };
        }
    }
}
