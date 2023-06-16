using MediatR;
using Microsoft.Extensions.Logging;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.Core.Aggregate.Participant;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.BindParticipant
{
    public class BindParticipantHandler : ICommandHandler<BindParticipantCommand, Unit>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly ILogger<BindParticipantHandler> _logger;

        public BindParticipantHandler(
            IBarbecueRepository barbecueRepository,
            IParticipantRepository participantRepository,
            ILogger<BindParticipantHandler> logger)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
            _logger = logger;
        }

        public Task<Unit> Handle(BindParticipantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin - [BindParticipantCommandHandler]");

            Barbecue? barbecue = _barbecueRepository.Get(request.model.BarbecueIdentifier);

            if (barbecue is null) return Task.FromResult(new Unit());

            if (barbecue.Participants.Contains(request.model.ParticipantIdentifier)) return Task.FromResult(new Unit());

            Participant? participant = _participantRepository.Get(request.model.ParticipantIdentifier);

            if (participant is null) return Task.FromResult(new Unit());

            barbecue.AddParticipant(request.model.ParticipantIdentifier);

            _barbecueRepository.Update(barbecue);

            _logger.LogInformation($"End - [BindParticipantCommandHandler]");
            return Task.FromResult(new Unit());
        }
    }
}
