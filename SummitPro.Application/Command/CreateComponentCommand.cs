using MediatR;
using SummitPro.Application.UseCase.CreateComponent;

namespace SummitPro.Application.Command
{
    public record CreateComponentCommand(CreateComponentInputBoundary input) : IRequest;
}
