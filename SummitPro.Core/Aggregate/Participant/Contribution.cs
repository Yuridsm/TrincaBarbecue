using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.DomainException;

namespace SummitPro.Core.Aggregate.Participant
{
    public class Contribution : IValueObject
    {
        public double Value { get; private set; }

        public Contribution(double value)
        {
            if (!Validate(value)) throw new InvalidContributionException("Invalid Contribution");

            Value = value;
        }

        public static bool Validate(double value)
        {
            if (value < 0) return false;
            return true;
        }
    }
}
