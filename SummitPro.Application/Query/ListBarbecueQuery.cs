using SummitPro.Application.OutputBoundary;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query
{
    public record ListBarbecueQuery() : IQuery<ListBarbecuesQueryModel>;
}
