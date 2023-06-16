using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.GetParticipantById
{
    public record GetParticipantByIdQuery(Guid ParticipantIdentifer) : IQuery<GetParticipantByIdQueryModel>;
}
