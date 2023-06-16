using MediatR;

using SummitPro.Application.Command;
using SummitPro.Application.CommandModel;
using SummitPro.Application.Interface;
using SummitPro.Core.Aggregate.Participant;

namespace SummitPro.Application.UseCase.AddParticipante
{
    public class AddParticipantUseCase : IAddParticipantUseCase
    {
        private readonly IMediator _mediator;

        public AddParticipantUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override AddParticipantOutputBoundary Execute(AddParticipantInputBoundary inputBoundary)
        {
            var entity = Participant
                .FactoryMethod(inputBoundary.Name, inputBoundary.Username, inputBoundary.SuggestionContribution)
                .AddBringDrink(inputBoundary.BringDrink)
                .AddItems(inputBoundary.Items);

            var model = new AddParticipantCommandModel
            {
                ParticipantIdentifier = entity.Identifier,
                Name = entity.Name.Value,
                Username = entity.Username.Value,
                SuggestionContribution = entity.ContributionValue.Value,
                BringDrink = entity.BringDrink,
                BarbecueIdentifier = inputBoundary.BarbecueIdentifier,
                Items = entity.Items
            };

            var command = new AddParticipantCommand(model);

            _mediator.Send(command);

            return new AddParticipantOutputBoundary
            {
                ParticipantIdentifier = entity.Identifier
            };
        }
    }
}
