using MediatR;
using SummitPro.Application.Command;
using SummitPro.Application.Query;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.UseCase.CreateComponent
{
    public class CreateComponentUseCase : IUseCaseAsynchronous
        .WithInputBoundary<CreateComponentInputBoundary>
        .WithoutOutputBoundary
    {
        private readonly IMediator _mediator;

        public CreateComponentUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task Execute(CreateComponentInputBoundary input)
        {
            var createCommand = new CreateComponentCommand(input);

            await _mediator.Send(createCommand);

            var createQuery = new ListComponenteQuery();

            var output = await _mediator.Send(createQuery);
        }
    }
}
