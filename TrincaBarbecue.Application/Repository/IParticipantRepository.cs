using TrincaBarbecue.Core.Aggregate.Participant;

namespace TrincaBarbecue.Application.Repository
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        IEnumerable<Participant> GetByIdentifiers(IEnumerable<Guid> identifier);
    }
}
