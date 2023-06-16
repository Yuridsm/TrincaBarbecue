using SummitPro.Application.UseCase.CalculateMinimumContribution;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface
{
    public abstract class ICalculateMinimumContributionUseCase : IUseCaseAsynchronous
        .WithInputBoundary<CalculateContributionInputBoundary>
        .WithOutputBoundary<CalculateContributionOutputBoundary>
    {

    }
}
