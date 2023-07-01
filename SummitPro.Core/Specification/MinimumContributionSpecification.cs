using SummitPro.Core.Aggregate.Participant;
using SummitPro.SharedKernel.Specification;

namespace SummitPro.Core.Specification;

public class MinimumContributionSpecification : AbstractSpecification<Contribution>
{
	public override bool IsSatisfied(Contribution entity)
	{
		return entity.Value >= 99.99d;
	}
}
