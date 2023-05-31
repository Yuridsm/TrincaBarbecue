using TrincaBarbecue.Core;

namespace TrincaBarbecue.Application.UseCase.AddParticipante
{
    public class AddParticipantInputBoundary : IInputBoundary
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public double SuggestionContribution { get; set; } = 0;
        public bool BringDrink { get; set; } = false;
        public Guid BarbecueIdentifier { get; set; }
    }
}
