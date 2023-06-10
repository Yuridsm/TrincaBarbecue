using MediatR;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.UseCase.UpdateBarbecue
{
    public class UpdateBarbecueUseCase : IUseCaseAsynchronous
        .WithInputBoundary<UpdateBarbecueInputBoundary>
        .WithOutputBoundary<UpdateBarbecueOutputBoundary>
    {
        private readonly IMediator _mediator;

        public UpdateBarbecueUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override Task<UpdateBarbecueOutputBoundary> Execute(UpdateBarbecueInputBoundary inputBoundary)
        {
            throw new NotImplementedException();
        }
    }
}
