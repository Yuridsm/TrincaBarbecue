namespace TrincaBarbecue.SharedKernel.Interfaces
{
    public interface ICachedRepository<T> where T : IEntity<Guid>, IAggregateRoot
    {
        void Set(string key, T value);
        T? Get(string key);
        IEnumerable<T> GetAll();
    }
}
