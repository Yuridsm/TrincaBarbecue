using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.AddParticipante
{
    public class AddParticipantOutputBoundary : IOutputBoundary
    {
        public Guid ParticipantIdentifier { get; set; }
    }
}
