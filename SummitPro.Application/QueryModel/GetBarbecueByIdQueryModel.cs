using SummitPro.Application.Model;

namespace SummitPro.Application.OutputBoundary
{
    public class GetBarbecueByIdQueryModel
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; }
        public IEnumerable<ParticipantModel> Participants { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> AdditionalRemarks { get; set; }
    }
}
