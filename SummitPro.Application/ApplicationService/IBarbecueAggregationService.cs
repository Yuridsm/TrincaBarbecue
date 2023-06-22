using SummitPro.Application.Model;

namespace SummitPro.Application.ApplicationService
{
    public interface IBarbecueAggregationService
    {
        BarbecueModel? Aggregate(Guid barbecueIdentifier);
    }
}
