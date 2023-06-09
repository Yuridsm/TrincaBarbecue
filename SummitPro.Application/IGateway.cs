namespace SummitPro.Application
{
    public interface IGateway<T>
    {
        void Insert(T dataModel);
        IEnumerable<T> GetAll();
        T GetByName(string name);
    }
}
