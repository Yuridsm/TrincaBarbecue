using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.UseCase.AddParticipante
{
    public class AddParticipantOutputBoundary : IOutputBoundary
    {
        public Guid ParticipantIdentifier { get; set; }
    }
}
