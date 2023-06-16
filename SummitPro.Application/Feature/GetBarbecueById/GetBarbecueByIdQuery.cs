using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.GetBarbecueById
{
    public record GetBarbecueByIdQuery(Guid BarbecueIdentifier) : IQuery<GetBarbecueByIdQueryModel>;
}
