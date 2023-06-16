using MediatR;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.UpdateBarbecue
{
    public record UpdateBarbecueCommand(UpdateBarbecueCommandModel model) : ICommand<Unit>;
}
