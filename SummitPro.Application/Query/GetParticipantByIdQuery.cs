using SummitPro.Application.QueryModel;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query
{
    public record GetParticipantByIdQuery(Guid ParticipantIdentifer) : IQuery<GetParticipantByIdQueryModel>;
}
