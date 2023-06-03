using System.Text.Json.Serialization;
using TrincaBarbecue.SharedKernel.DomainException;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Core.Aggregate.Barbecue
{
    public class Barbecue : IEntity<Guid>, IAggregateRoot
    {
        public Guid Identifier { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public List<string> AdditionalRemarks { get; private set; } = new List<string>();
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<Guid> Participants { get; private set; } = new List<Guid>();

        private Barbecue(string description, List<string> additionalRemarks, DateTime beginDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("You must give a description");
            if (beginDate > endDate) throw new DateTimeDoesNotMatchException("You must give valid date");

            Description = description;
            AdditionalRemarks = additionalRemarks;
            BeginDate = beginDate;
            EndDate = endDate;
            Identifier = Guid.NewGuid();
        }

        // Used for Assembly Instance
        [JsonConstructor]
        public Barbecue(Guid identifier, string description, List<string> additionalRemarks, DateTime beginDate, DateTime endDate, List<Guid> participants)
        {
            Identifier = identifier;
            Description = description;
            AdditionalRemarks = additionalRemarks;
            BeginDate = beginDate;
            EndDate = endDate;
            Participants = participants;
        }

        public static Barbecue FactoryMethod(string description, List<string> additionalRemarks, DateTime beginDate, DateTime endDate)
        {
            var barbebueEntity = new Barbecue(description, additionalRemarks, beginDate, endDate);
            return barbebueEntity;
        }

        public void Reschedule(DateTime begin, DateTime end)
        {
            BeginDate = begin; 
            EndDate = end;
        }

        public Barbecue AddParticipant(Guid identifier)
        {
            Participants.Add(identifier);
            return this;
        }

        public void RemoveParticipant(Guid identifier)
        {
            Guid p = Participants.Find(participantIdentifier => participantIdentifier == identifier);

            if (p != Guid.Empty) Participants.Remove(p);
        }

        public int ParticipantsQuantity()
        {
            return Participants.Count;
        }

        public Barbecue AddAdditionalRemark(string remark)
        {
            AdditionalRemarks.Add(remark);
            return this;
        }

        public Barbecue AddDescription(string description)
        {
            Description = description;
            return this;
        }

        public Barbecue Build()
        {
            return this;
        }
    }
}
