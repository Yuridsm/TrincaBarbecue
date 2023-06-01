using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.Repository
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        IEnumerable<Participant> GetByIdentifiers(IEnumerable<Guid> identifier);
    }
}
