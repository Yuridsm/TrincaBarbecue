using MediatR;
using SummitPro.Application.Command;
using SummitPro.Application.CommandModel;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueUseCase : IUseCaseAsynchronous
        .WithInputBoundary<CreateBarbecueInputBoundary>
        .WithOutputBoundary<CreatebarbecueOutputBoundary>
    {
        private ICachedRepository _cachedRepository;
        private readonly IMediator _mediator;

        public CreateBarbecueUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public CreateBarbecueUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override async Task<CreatebarbecueOutputBoundary> Execute(CreateBarbecueInputBoundary input)
        {
            var entity = Barbecue.FactoryMethod(input.Description, input.AdditionalObservations, input.BeginDate, input.EndDate);

            var commandModel = new CreateBarbecueCommandModel
            {
                BeginDate = entity.BeginDate,
                EndDate = entity.EndDate,
                Description = entity.Description,
                Participants = entity.Participants,
                AdditionalObservations = entity.AdditionalRemarks
            };

            var createBarbecueCommand = new CreateBarbecueCommand(commandModel);

            await _mediator.Send(createBarbecueCommand);

            if (_cachedRepository != null) _cachedRepository.Set(entity.Identifier.ToString(), entity);

            return new CreatebarbecueOutputBoundary(entity.Identifier);
        }
    }
}
