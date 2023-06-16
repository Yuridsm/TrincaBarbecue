using MediatR;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.Core.Aggregate.Participant;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.AddParticipante
{
    public class AddParticipantHandler : ICommandHandler<AddParticipantCommand, Unit>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;

        public AddParticipantHandler(
            IBarbecueRepository barbecueRepository,
            IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public Task<Unit> Handle(AddParticipantCommand request, CancellationToken cancellationToken)
        {
            Barbecue? barbecue = _barbecueRepository.Get(request.model.BarbecueIdentifier);

            if (barbecue == null) throw new ArgumentException("There is no barbecue signed.");

            var participant = Participant.FactoryMethod(
                request.model.ParticipantIdentifier,
                request.model.Name,
                request.model.SuggestionContribution,
                request.model.Username,
                request.model.Items.ToList(),
                request.model.BringDrink
                );

            _participantRepository.Add(participant);

            return Task.FromResult(new Unit());
        }
    }
}
