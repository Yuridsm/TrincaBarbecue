using MediatR;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Command
{
    public record CreateBarbecueCommand(Barbecue input) : ICommand<Unit>;
}
