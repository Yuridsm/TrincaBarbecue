using SummitPro.Core.Aggregate.Participant;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.Repository
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        IEnumerable<Participant?> GetByIdentifiers(IEnumerable<Guid> identifier);
    }
}
