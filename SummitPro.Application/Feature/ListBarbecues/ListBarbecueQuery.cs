using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.ListBarbecues
{
    public record ListBarbecueQuery() : IQuery<ListBarbecuesQueryModel>;
}
