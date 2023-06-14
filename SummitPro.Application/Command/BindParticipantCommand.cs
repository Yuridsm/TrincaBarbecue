using MediatR;
using SummitPro.Application.CommandModel;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Command
{
    public record BindParticipantCommand(BindParticipantCommandModel model) : ICommand<Unit>;
}
