using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface
{
    public abstract class IAddParticipantUseCase : IUseCaseSinchronous
        .WithInputBoundary<AddParticipantInputBoundary>
        .WithOutputBoundary<AddParticipantOutputBoundary>
    {
    }
}
