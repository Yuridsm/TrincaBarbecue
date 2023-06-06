using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.BindParticipant
{
    public class BindParticipantInputBoundary : IInputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
        public Guid ParticipantIdentifier { get; set; }
    }
}
