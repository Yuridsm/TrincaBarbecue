using TrincaBarbecue.Core;

namespace TrincaBarbecue.Application.UseCase.AddParticipante
{
    public class AddParticipantOutputBoundary : IOutputBoundary
    {
        public Guid ParticipantIdentifier { get; set; }
    }
}
