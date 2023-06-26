namespace SummitPro.Application.Feature.GetBarbecueById
{
    public class GetBarbecueByIdQueryModel
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Guid> Participants { get; set; } = Enumerable.Empty<Guid>();
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> AdditionalRemarks { get; set; } = new();
        public double TotalContribution { get; set; }
    }
}
