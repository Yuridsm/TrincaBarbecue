namespace SummitPro.SharedKernel.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity? Get(Guid identifier);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        TEntity Find(Predicate<TEntity> action);
        void Update(TEntity entity);
    }
}
