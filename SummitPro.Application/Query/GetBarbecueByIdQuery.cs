using SummitPro.Application.OutputBoundary;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query
{
    public record GetBarbecueByIdQuery(Guid BarbecueIdentifier) : IQuery<GetBarbecueByIdQueryModel>;
}
