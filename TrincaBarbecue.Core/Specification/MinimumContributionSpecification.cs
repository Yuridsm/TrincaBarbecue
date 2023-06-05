using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.SharedKernel.Specification;

namespace TrincaBarbecue.Core.Specification
{
    public class MinimumContributionSpecification : AbstractSpecification<Contribution>
    {
        public override bool IsSatisfied(Contribution entity)
        {
            return entity.Value >= 99.99d;
        }
    }
}
