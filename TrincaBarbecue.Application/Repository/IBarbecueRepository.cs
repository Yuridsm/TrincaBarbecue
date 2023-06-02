using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.Repository
{
    public interface IBarbecueRepository : IRepository<Barbecue>
    {
        IEnumerable<Barbecue> GetByIdentifiers(IEnumerable<Guid> identifier);
    }
}
