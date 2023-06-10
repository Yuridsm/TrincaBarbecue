namespace SummitPro.Application.Model
{
    public class ParticipantModel
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public double ContributionValue { get; set; }
        public string BringDrink { get; set; }
        public List<string> Items { get; set; }
        public string Username { get; set; }
    }
}
