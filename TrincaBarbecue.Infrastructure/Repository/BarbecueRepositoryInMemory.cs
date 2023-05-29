using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;

namespace TrincaBarbecue.Infrastructure.Repository
{
    public class BarbecueRepositoryInMemory : IBarbecueRepository
    {
        private List<Barbecue> _barbecues = new List<Barbecue>();

        public void Add(Barbecue entity)
        {
            _barbecues.Add(entity);
        }

        public Barbecue Find(Action<Barbecue> action)
        {
            throw new NotImplementedException();
        }

        public Barbecue? Get(Guid identifier)
        {
            return _barbecues.Find(o => o.Identifier == identifier);
        }
    }
}
