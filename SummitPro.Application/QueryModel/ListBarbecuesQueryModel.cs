using SummitPro.Application.Model;

namespace SummitPro.Application.OutputBoundary
{
    public class ListBarbecuesQueryModel
    {
        public IEnumerable<BarbecueModel> Barbecues { get; set; }
    }
}
