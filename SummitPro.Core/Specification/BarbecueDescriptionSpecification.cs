using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Specification;

namespace SummitPro.Core.Specification
{
    public class BarbecueDescriptionSpecification : AbstractSpecification<Barbecue>
    {
        public override bool IsSatisfied(Barbecue entity)
        {
            if (entity == null) return false;

            if (string.IsNullOrEmpty(entity.Description)) return false;

            return true;
        }
    }
}
