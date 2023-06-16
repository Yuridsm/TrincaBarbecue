namespace SummitPro.Application.OutputBoundary
{
    public class GetBarbecueByIdQueryModel
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; }
        public IEnumerable<Guid> Participants { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> AdditionalRemarks { get; set; }
        public double TotalContribution { get; set; }
    }
}
