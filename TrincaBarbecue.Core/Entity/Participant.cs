namespace TrincaBarbecue.Core.Entity
{
    public class Participant
    {
        public Guid Identifier { get; private set; }
        public Name Name { get; private set; }
        public Contribution ContributionValue { get; private set; }

        private Participant(Name name, Contribution contribution)
        {
            Identifier = Guid.NewGuid();
            Name = name;
            ContributionValue = contribution;
        }

        public static Participant FactoryMethod(string name, double valueContribution)
        {
            return new Participant(new Name(name), new Contribution(valueContribution));
        }


    }
}
