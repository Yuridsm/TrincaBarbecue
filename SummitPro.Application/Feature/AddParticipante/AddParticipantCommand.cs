using MediatR;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.AddParticipante
{
    public record AddParticipantCommand(AddParticipantCommandModel model) : ICommand<Unit>;
}
