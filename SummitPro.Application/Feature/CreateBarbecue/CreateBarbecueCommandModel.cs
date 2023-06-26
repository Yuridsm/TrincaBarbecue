namespace SummitPro.Application.Feature.CreateBarbecue
{
    public class CreateBarbecueCommandModel
    {
        public Guid BarbecueIdentifier { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> AdditionalObservations { get; set; } = new ();
        public List<Guid> Participants { get; set; } = new List<Guid>();
    }
}
