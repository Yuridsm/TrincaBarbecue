using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.SharedKernel.Interfaces;
using TrincaBarbecue.SharedKernel.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.BindParticipant
{
    public class BindParticipantUseCase : IUseCaseSinchronous
        .WithInputBoundary<BindParticipantInputBoundary>
        .WithoutOutputBoundary
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;
        private ICachedRepository _cachedRepository;

        public BindParticipantUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public BindParticipantUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override void Execute(BindParticipantInputBoundary inputBoundary)
        {
            if (inputBoundary == null) throw new ArgumentNullException("Input can not be empty.");

            if (_cachedRepository != null)
            {
                var barbecue = _cachedRepository.Get<Barbecue>(inputBoundary.BarbecueIdentifier.ToString());

                if (barbecue == null) throw new ArgumentException("Barbecue does not exist.");

                if (barbecue.Participants.Contains(inputBoundary.ParticipantIdentifier)) return;

                var participant = _cachedRepository.Get<Participant>(inputBoundary.ParticipantIdentifier.ToString());

                if (participant == null) throw new ArgumentNullException("Participant does not exist.");

                barbecue.AddParticipant(inputBoundary.ParticipantIdentifier);

                _cachedRepository.DeleteList<Barbecue>(inputBoundary.BarbecueIdentifier.ToString());
                _cachedRepository.Set<Barbecue>(inputBoundary.BarbecueIdentifier.ToString(), barbecue);
            }
            else
            {
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
}
