namespace SummitPro.Application.Feature.AddParticipante
{
    public class AddParticipantCommandModel
    {
        public Guid ParticipantIdentifier { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public double SuggestionContribution { get; set; } = 0;
        public bool BringDrink { get; set; } = false;
        public Guid BarbecueIdentifier { get; set; }
        public IEnumerable<string> Items { get; set; } = Enumerable.Empty<string>();
    }
}
