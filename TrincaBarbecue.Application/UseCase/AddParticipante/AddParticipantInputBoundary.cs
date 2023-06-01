using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.UseCase.AddParticipante
{
    public class AddParticipantInputBoundary : IInputBoundary
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public double SuggestionContribution { get; set; } = 0;
        public bool BringDrink { get; set; } = false;
        public Guid BarbecueIdentifier { get; set; }
        public IEnumerable<string> Items { get; set; }

        public AddParticipantInputBoundary(
            string name,
            string username,
            double suggestionContribution,
            bool bringDrink,
            Guid barbecueIdentifier,
            IEnumerable<string> items)
        {
            Name = name;
            Username = username;
            SuggestionContribution = suggestionContribution;
            BringDrink = bringDrink;
            BarbecueIdentifier = barbecueIdentifier;
            Items = items;
        }
    }
}
