using MediatR;
using SummitPro.Application.Command;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueUseCase : IUseCaseAsynchronous
        .WithInputBoundary<CreateInputBoundary>
        .WithOutputBoundary<CreateOutputBoundary>
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

        public override async Task<CreateOutputBoundary> Execute(CreateInputBoundary input)
        {
            var entity = Barbecue.FactoryMethod(input.Description, input.AdditionalObservations, input.BeginDate, input.EndDate);

            var createBarbecueCommand = new CreateBarbecueCommand(entity);

            var foo = await _mediator.Send(createBarbecueCommand);

            if (_cachedRepository != null) _cachedRepository.Set(entity.Identifier.ToString(), entity);

            return CreateOutputBoundary.FactoryMethod(entity.Identifier);
        }
    }
}
