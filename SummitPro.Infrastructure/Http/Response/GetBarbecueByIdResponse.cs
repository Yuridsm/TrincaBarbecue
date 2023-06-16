using SummitPro.Application.Model;

namespace SummitPro.Infrastructure.Http.Response
{
    public class GetBarbecueByIdResponse
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BeginDateTime { get; set; } = string.Empty;
        public string EndDateTime { get; set; } = string.Empty;
        public IEnumerable<string> AdditionalRemarks { get; set; }
        public IEnumerable<ParticipantModel> Participants { get; set; }
    }
}
