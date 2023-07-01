using SummitPro.Core.Aggregate.Participant;
using SummitPro.SharedKernel.Specification;

namespace SummitPro.Core.Specification;

public class ParticipantUsernameSpecification : AbstractSpecification<Username>
{
	public override bool IsSatisfied(Username entity)
	{
		return entity.Value.StartsWith("@");
	}
}
