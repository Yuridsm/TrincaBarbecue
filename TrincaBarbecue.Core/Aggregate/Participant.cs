namespace TrincaBarbecue.Core.Aggregate
{
    public class Participant : IEntity<Guid>
    {
        public Guid Identifier { get; private set; }
        public Name Name { get; private set; }
        public Contribution ContributionValue { get; private set; }
        public bool BringDrink { get; private set; }
        public List<string> Items { get; private set; }

        private Participant(Name name, Contribution contribution, bool bringDrink = false)
        {
            Identifier = Guid.NewGuid();
            Name = name;
            ContributionValue = contribution;
            BringDrink = bringDrink;
            Items = new List<string>();
        }

        public static Participant FactoryMethod(string name, bool bringDrink = false)
        {
            return new Participant(new Name(name), new Contribution(0.0f), bringDrink);
        }

        public static Participant FactoryMethod(string name, double contributionSugestion, bool bringDrink = false)
        {
            return new Participant(new Name(name), new Contribution(contributionSugestion), bringDrink);
        }

        public Participant AddItem(string item)
        {
            Items.Add(item);
            return this;
        }

        public Participant AddItems(IEnumerable<string> items)
        {
            Items.AddRange(items);
            return this;
        }
    }
}
