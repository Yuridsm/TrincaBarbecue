using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query
{
    public record GetBarbecueByIdQuery(Guid barbecueIdentifier) : IQuery<Response>;

    public record Response(Guid Id, string Description);
}
