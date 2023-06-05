using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.SharedKernel.Specification;

namespace TrincaBarbecue.Core.Specification
{
    public class ParticipantUsernameSpecification : AbstractSpecification<Username>
    {
        public override bool IsSatisfied(Username entity)
        {
            return entity.Value.StartsWith("@");
        }
    }
}
