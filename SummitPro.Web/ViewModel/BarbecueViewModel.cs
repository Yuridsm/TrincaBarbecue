namespace SummitPro.Web.ViewModel
{
    public class BarbecueViewModel
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime BeginDate { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<string> AdditionalRemarks { get; set; } = new();

        public override string ToString()
        {
            return $"Description: {Description}" +
                $"BeginDate: {BeginDate}" +
                $"EndDate: {EndDateTime}";
        }
    }
}
