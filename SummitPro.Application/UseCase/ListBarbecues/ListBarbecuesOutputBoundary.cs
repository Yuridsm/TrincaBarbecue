using SummitPro.Application.Model;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.ListBarbecues
{
    public class ListBarbecuesOutputBoundary : IOutputBoundary
    {
        public IEnumerable<BarbecueModel> Barbecues { get; set; }
    }
}
