using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.UseCase.GetParticipant
{
    public class GetParticipantsOutputBoundary : IOutputBoundary
    {
        public IEnumerable<Participant> Participants { get; set; }
    }

    public class Participant
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public double Contribution { get; set; }
        public string BringDrink { get; set; }
        public IEnumerable<string> Items { get; set; }
        public string Username { get; set; }
    }
}
