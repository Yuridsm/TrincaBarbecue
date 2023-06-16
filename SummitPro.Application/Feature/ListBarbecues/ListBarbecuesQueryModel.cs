using SummitPro.Application.Model;

namespace SummitPro.Application.Feature.ListBarbecues
{
    public class ListBarbecuesQueryModel
    {
        public IEnumerable<BarbecueModel> Barbecues { get; set; }
    }
}
