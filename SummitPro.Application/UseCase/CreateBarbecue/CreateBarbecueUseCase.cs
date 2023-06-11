using MediatR;

using SummitPro.Application.Command;
using SummitPro.Application.CommandModel;
using SummitPro.Application.Interface;
using SummitPro.Core.Aggregate.Barbecue;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueUseCase : ICreateBarbecueUseCase
    {
        private readonly IMediator _mediator;

        public CreateBarbecueUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<CreateBarbecueOutputBoundary> Execute(CreateBarbecueInputBoundary input)
        {
            var entity = Barbecue.FactoryMethod(input.Description, input.AdditionalObservations, input.BeginDate, input.EndDate);

            var commandModel = new CreateBarbecueCommandModel
            {
                BarbecueIdentifier = entity.Identifier,
                BeginDate = entity.BeginDate,
                EndDate = entity.EndDate,
                Description = entity.Description,
                Participants = entity.Participants,
                AdditionalObservations = entity.AdditionalRemarks
            };

            var createBarbecueCommand = new CreateBarbecueCommand(commandModel);

            await _mediator.Send(createBarbecueCommand);

            return new CreateBarbecueOutputBoundary(entity.Identifier);
        }
    }
}
