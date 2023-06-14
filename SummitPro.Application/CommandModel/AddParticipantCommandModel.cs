namespace SummitPro.Application.CommandModel
{
    public class AddParticipantCommandModel
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public double SuggestionContribution { get; set; } = 0;
        public bool BringDrink { get; set; } = false;
        public Guid BarbecueIdentifier { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}
