using SummitPro.Application.Model;

namespace SummitPro.Web.Endpoints.Barbecue
{
    public class GetResponse
    {
        public Guid Identifier { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BeginDateTime { get; set; } = string.Empty;
        public string EndDateTime { get; set; } = string.Empty;
        public IEnumerable<string> AdditionalRemarks { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<ParticipantModel> Participants { get; set; } = Enumerable.Empty<ParticipantModel>();
    }
}
