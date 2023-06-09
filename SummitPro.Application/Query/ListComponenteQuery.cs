using MediatR;
using SummitPro.Application.UseCase.CreateComponent;

namespace SummitPro.Application.Query
{
    public record ListComponenteQuery() : IRequest<CreateComponentOutputBoundary>;
}
