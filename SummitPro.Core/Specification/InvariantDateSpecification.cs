using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Specification;

namespace SummitPro.Core.Specification
{
    public class InvariantDateSpecification : AbstractSpecification<Barbecue>
    {
        public override bool IsSatisfied(Barbecue entity)
        {
            if (entity == null) return false;

            if (entity.EndDate <= entity.BeginDate) return false;

            return true;
        }
    }
}
