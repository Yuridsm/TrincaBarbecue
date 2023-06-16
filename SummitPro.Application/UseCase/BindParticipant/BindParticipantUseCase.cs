using MediatR;

using SummitPro.Application.Command;
using SummitPro.Application.CommandModel;
using SummitPro.Application.Interface;
using SummitPro.Application.Query;

namespace SummitPro.Application.UseCase.BindParticipant
{
    public class BindParticipantUseCase : IBindParticipantUseCase
    {
        private readonly IMediator _mediator;

        public BindParticipantUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task Execute(BindParticipantInputBoundary inputBoundary)
        {
            var bindParticipantCommandModel = new BindParticipantCommandModel
            {
                BarbecueIdentifier = inputBoundary.BarbecueIdentifier,
                ParticipantIdentifier = inputBoundary.ParticipantIdentifier
            };

            var bindParticipantCommand = new BindParticipantCommand(bindParticipantCommandModel);

            await _mediator.Send(bindParticipantCommand);
        }
    }
}
