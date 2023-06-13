using SummitPro.Application.UseCase.UpdateBarbecue;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface
{
    public abstract class IUpdateBarbecueUseCase : IUseCaseAsynchronous
        .WithInputBoundary<UpdateBarbecueInputBoundary>
        .WithoutOutputBoundary
    {
    }
}
