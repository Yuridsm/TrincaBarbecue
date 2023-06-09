using MediatR;
using SummitPro.Application.UseCase.CreateComponent;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Command
{
    public record CreateComponentCommand(CreateComponentInputBoundary input) : ICommand<Unit>;
}
