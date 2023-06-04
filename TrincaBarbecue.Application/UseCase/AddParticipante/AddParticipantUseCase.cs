using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
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
        private ICachedRepository _cachedRepository;

        public AddParticipantUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public AddParticipantUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override AddParticipantOutputBoundary Execute(AddParticipantInputBoundary inputBoundary)
        {
            Barbecue barbecue = default(Barbecue);

            if (_cachedRepository == null)
                barbecue = _barbecueRepository.Get(inputBoundary.BarbecueIdentifier);
            else
                barbecue = _cachedRepository.Get<Barbecue>(inputBoundary.BarbecueIdentifier.ToString());

            if (barbecue == null) throw new ArgumentException("There is no barbecue signed.");

            var participant = Participant
                .FactoryMethod(
                    inputBoundary.Name,
                    inputBoundary.Username,
                    inputBoundary.SuggestionContribution);

            // In Memory in one Process
            participant.AddItems(inputBoundary.Items);
            _participantRepository.Add(participant);

            // In Distributed Cache
            if (_cachedRepository != null)
            { 
                //_cachedRepository.DeleteList<Barbecue>(inputBoundary.BarbecueIdentifier.ToString());
                //_cachedRepository.Set(inputBoundary.BarbecueIdentifier.ToString(), barbecue);
                _cachedRepository.Set<Participant>(participant.Identifier.ToString(), participant);
            }

            return new AddParticipantOutputBoundary { ParticipantIdentifier = participant.Identifier };
        }
    }
}
