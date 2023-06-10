namespace SummitPro.Application.CommandModel
{
    public class CreateBarbecueCommandModel
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string>? AdditionalObservations { get; set; } = new List<string>();
        public List<Guid>? Participants { get; set; } = new List<Guid>();
    }
}
