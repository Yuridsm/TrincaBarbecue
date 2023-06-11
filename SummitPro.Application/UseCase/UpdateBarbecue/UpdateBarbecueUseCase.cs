using MediatR;
using SummitPro.Application.Command;
using SummitPro.Application.CommandModel;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.UseCase.UpdateBarbecue
{
    public class UpdateBarbecueUseCase : IUseCaseAsynchronous
        .WithInputBoundary<UpdateBarbecueInputBoundary>
        .WithoutOutputBoundary
    {
        private readonly IMediator _mediator;

        public UpdateBarbecueUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task Execute(UpdateBarbecueInputBoundary inputBoundary)
        {
            var model = new UpdateBarbecueCommandModel
            {
                BarbecueIdentifier = inputBoundary.BarbecueIdentifier,
                AdditionalMarks = inputBoundary.AdditionalMarks,
                BeginDate = inputBoundary.BeginDate,
                EndDate = inputBoundary.EndDate,
                Description = inputBoundary.Description
            };

            var command = new UpdateBarbecueCommand(model);

            await _mediator.Send(command);
        }
    }
}
