using MediatR;
using SummitPro.Application.Repository;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Command.Handler
{
    public class BindParticipantHandler : ICommandHandler<BindParticipantCommand, Unit>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;

        public BindParticipantHandler(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public Task<Unit> Handle(BindParticipantCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
