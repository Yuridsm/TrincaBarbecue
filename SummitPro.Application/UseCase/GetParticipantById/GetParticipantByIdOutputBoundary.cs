using SummitPro.Application.Model;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.GetParticipant
{
    public class GetParticipantByIdOutputBoundary : IOutputBoundary
    {
        public ParticipantModel Participant { get; set; }
    }
}
