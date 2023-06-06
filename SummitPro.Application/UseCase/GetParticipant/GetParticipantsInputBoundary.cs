using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.GetParticipant
{
    public class GetParticipantsInputBoundary : IInputBoundary
    {
        public IEnumerable<Guid> ParticipantIdentifiers { get; set; }
    }
}
