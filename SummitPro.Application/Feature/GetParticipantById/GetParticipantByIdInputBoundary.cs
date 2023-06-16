using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.GetParticipant
{
    public class GetParticipantByIdInputBoundary : IInputBoundary
    {
        public Guid ParticipantIdentifier { get; set; }
    }
}
