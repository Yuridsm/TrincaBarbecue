using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Core.Aggregate.Participant
{
    public class Participant : IEntity<Guid>, IAggregateRoot
    {
        public Guid Identifier { get; private set; }
        public Name Name { get; private set; }
        public Contribution ContributionValue { get; private set; }
        public bool BringDrink { get; private set; }
        public List<string> Items { get; private set; }
        public Username Username { get; private set; }

        private Participant(Name name, Username username, Contribution contribution, bool bringDrink = false)
        {
            Identifier = Guid.NewGuid();
            Name = name;
            ContributionValue = contribution;
            BringDrink = bringDrink;
            Items = new List<string>();
            Username = username;
        }

        public Participant(Guid identifer, Name name, Contribution contributionValue, bool bringDrink, List<string> items, Username username)
        {
            Identifier = identifer;
            Name = name;
            ContributionValue = contributionValue;
            BringDrink = bringDrink;
            Items = new List<string>();
            Username = username;
        }

        public static Participant FactoryMethod(string name, string username, bool bringDrink = false)
        {
            return new Participant(new Name(name), new Username(username), new Contribution(0.0f), bringDrink);
        }

        public static Participant FactoryMethod(string name, string username, double contributionSugestion, bool bringDrink = false)
        {
            return new Participant(new Name(name), new Username(username), new Contribution(contributionSugestion), bringDrink);
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

        public Participant UpdateUsername(string username)
        {
            Username = new Username(username);
            return this;
        }

        public Participant AddBringDrink(bool bringDrinks)
        {
            BringDrink = bringDrinks;
            return this;
        }

        public Participant Build()
        {
            return this;
        }
    }
}
