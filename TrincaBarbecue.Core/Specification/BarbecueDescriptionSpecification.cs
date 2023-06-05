using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.SharedKernel.Specification;

namespace TrincaBarbecue.Core.Specification
{
    public class BarbecueDescriptionSpecification : AbstractSpecification<Barbecue>
    {
        public override bool IsSatisfied(Barbecue entity)
        {
            if (entity == null) return false;

            if(string.IsNullOrEmpty(entity.Description)) return false;

            return true;
        }
    }
}
