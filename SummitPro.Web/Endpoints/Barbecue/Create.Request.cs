namespace SummitPro.Web.Endpoints.Barbecue
{
    public class CreateRequest
    {
        public string BeginDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> AdditionalObservations { get; set; } = new();
    }
}
