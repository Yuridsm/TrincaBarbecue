namespace SummitPro.Application.Model
{
    public class BarbecueModel
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<ParticipantModel> Participants { get; set; } = new List<ParticipantModel>();
        public string BeginDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public List<string> AdditionalRemarks { get; set; } = new ();
    }

    public class BarbecueModelBuilder
    {
        private readonly BarbecueModel _model = new();

        public BarbecueModelBuilder AddBarbecueIdentifier(Guid barbecueIdentifier)
        {
            _model.BarbecueIdentifier = barbecueIdentifier;
            return this;
        }

        public BarbecueModelBuilder AddDescription(string description)
        {
            _model.Description = description;
            return this;
        }

        public BarbecueModelBuilder AddBeginDate(string beginDate)
        {
            _model.BeginDate = beginDate;
            return this;
        }

        public BarbecueModelBuilder AddEndDate(string endDate)
        {
            _model.EndDate = endDate;
            return this;
        }

        public BarbecueModelBuilder AddAdditionalRemarks(List<string> additionalRemarks)
        {
            _model.AdditionalRemarks = additionalRemarks;
            return this;
        }

        public BarbecueModelBuilder AddParticipant(ParticipantModel participant)
        {
            _model.Participants.Add(participant);
            return this;
        }

        public BarbecueModelBuilder AddParticipants(ICollection<ParticipantModel> participants)
        {
            _model.Participants = participants;
            return this;
        }

        public BarbecueModel Build()
        {
            return _model;
        }
    }
}
