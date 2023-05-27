using TrincaBarbecue.Core.Aggregate;

namespace TrincaBarbecue.Application.Repository
{
    public interface IBarbecueRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot {}
}
