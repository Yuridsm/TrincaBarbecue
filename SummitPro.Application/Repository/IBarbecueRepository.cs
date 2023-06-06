using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.Repository
{
    public interface IBarbecueRepository : IRepository<Barbecue>
    {
        IEnumerable<Barbecue> GetByIdentifiers(IEnumerable<Guid> identifier);
    }
}
