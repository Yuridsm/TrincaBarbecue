using MediatR;
using SummitPro.Application.Interface;
using SummitPro.Application.Repository;

namespace SummitPro.Application.UseCase.BindParticipant
{
    public class BindParticipantUseCase : IBindParticipantUseCase
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMediator _mediator;

        public BindParticipantUseCase(
            IBarbecueRepository barbecueRepository, 
            IParticipantRepository participantRepository,
            IMediator mediator
            )
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
            _mediator = mediator;
        }

        public override void Execute(BindParticipantInputBoundary inputBoundary)
        {
            //if (inputBoundary == null) throw new ArgumentNullException("Input can not be empty.");

            //var barbecue = _barbecueRepository.Get(inputBoundary.BarbecueIdentifier);

            //if (barbecue == null) throw new ArgumentNullException("Barbecue does not exist.");

            //if (barbecue.Participants.Contains(inputBoundary.ParticipantIdentifier)) return;

            //var participant = _participantRepository.Get(inputBoundary.ParticipantIdentifier);

            //if (participant == null) throw new ArgumentNullException("Participant does not exist.");

            //barbecue.AddParticipant(inputBoundary.ParticipantIdentifier);

            //_barbecueRepository.Update(barbecue);

            //_mediator.Send();
        }
    }
}
