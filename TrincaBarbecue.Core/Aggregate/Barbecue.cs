using TrincaBarbecue.Core.DomainException;

namespace TrincaBarbecue.Core.Aggregate
{
    public class Barbecue : IEntity<Guid>, IAggregateRoot
    {
        public Guid Identifier { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public IEnumerable<string> AdditionalObservations { get; private set; } = new List<string>();
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<Participant> Participants { get; private set; } = new List<Participant>();

        private Barbecue(string description, IEnumerable<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("You must give a description");
            if (beginDate > endDate) throw new DateTimeDoesNotMatchException("You must give valid date");

            Description = description;
            AdditionalObservations = additionalObservations;
            BeginDate = beginDate;
            EndDate = endDate;
            Identifier = Guid.NewGuid();
        }

        public static Barbecue FactoryMethod(string description, IEnumerable<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            var barbebueEntity = new Barbecue(description, additionalObservations, beginDate, endDate);
            return barbebueEntity;
        }

        public Barbecue AddParticipant(string name)
        {
            Participants.Add(Participant.FactoryMethod(name));
            return this;
        }

        public Barbecue AddParticipant(string name, double contributionSugestion)
        {
            Participants.Add(Participant.FactoryMethod(name, contributionSugestion));
            return this;
        }

        public void RemoveParticipant(Guid identifier)
        {
            var p = Participants.Find(o => o.Identifier == identifier);

            if (p != null) Participants.Remove(p);
        }

        public Barbecue Build()
        {
            return this;
        }

        public int ParticipantsQuantity()
        {
            return Participants.Count;
        }

        public double CalculateMinimumContributionValue()
        {
            int participantsQuantity = Participants.Count;
            double total = Participants.Sum(o => o.ContributionValue.Value) / participantsQuantity;

            return total;
        }
    }
}
