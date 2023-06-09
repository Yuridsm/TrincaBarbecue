using SummitPro.Application;

namespace SummitPro.Infrastructure
{
    public class Gateway : IGateway<string>
    {
        private List<string> _components = new List<string>();

        public IEnumerable<string> GetAll()
        {
            return _components;
        }

        public string GetByName(string name)
        {
            return _components.Find(o => o.Contains(name)) ?? string.Empty;
        }

        public void Insert(string dataModel)
        {
            if (!string.IsNullOrEmpty(dataModel))
                _components.Add(dataModel);
        }
    }
}
