using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.SharedKernel.Specification;

namespace TrincaBarbecue.Core.Specification
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
