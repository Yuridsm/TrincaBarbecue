using MediatR;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.BindParticipant
{
    public record BindParticipantCommand(BindParticipantCommandModel model) : ICommand<Unit>;
}
