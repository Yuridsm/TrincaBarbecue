namespace SummitPro.SharedKernel.Interfaces
{
    public interface ICachedRepository
    {
        void Set<T>(string key, T value) where T : IEntity<Guid>, IAggregateRoot;
        T? Get<T>(string key) where T : IEntity<Guid>, IAggregateRoot;
        IEnumerable<T> GetAll<T>() where T : IEntity<Guid>, IAggregateRoot;
        long Delete<TEntity>(string key, string value) where TEntity : IEntity<Guid>, IAggregateRoot;
        bool DeleteList<TEntity>(string key) where TEntity : IEntity<Guid>, IAggregateRoot;
    }
}
