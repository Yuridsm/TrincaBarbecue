namespace SummitPro.Application.Model
{
    public class BarbecueModel
    {
        public Guid barbecueIdentifier { get; set; }
        public string Description { get; set; }
        public IEnumerable<ParticipantModel> Participants { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public List<string> AdditionalRemarks { get; set; }
    }
}
