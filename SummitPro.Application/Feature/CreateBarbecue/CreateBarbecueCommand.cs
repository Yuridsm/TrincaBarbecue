using MediatR;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.CreateBarbecue
{
    public record CreateBarbecueCommand(CreateBarbecueCommandModel input) : ICommand<Unit>;
}
