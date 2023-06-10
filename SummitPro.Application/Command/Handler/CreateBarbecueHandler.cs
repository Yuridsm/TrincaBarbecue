using MediatR;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Command.Handler
{
    public class CreateBarbecueHandler : ICommandHandler<CreateBarbecueCommand, Unit>
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public CreateBarbecueHandler(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public Task<Unit> Handle(CreateBarbecueCommand request, CancellationToken cancellationToken)
        {
            if (request is null || request.input is null) return Task.FromResult(new Unit());

            var entity = Barbecue.FactoryMethod(
                request.input.Description,
                request.input.AdditionalObservations,
                request.input.BeginDate,
                request.input.EndDate
                );
            
            if (request.input.Participants.Any())
            {
                foreach (var participant in request.input.Participants)
                    entity.AddParticipant(participant);
            }

            _barbecueRepository.Add(entity);

            return Task.FromResult(Unit.Value);
        }
    }
}
