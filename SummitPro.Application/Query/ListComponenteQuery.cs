using MediatR;
using SummitPro.Application.OutputBoundary;

namespace SummitPro.Application.Query
{
    public record ListComponenteQuery() : IRequest<IEnumerable<CreateComponentQueryModel>>;
}
