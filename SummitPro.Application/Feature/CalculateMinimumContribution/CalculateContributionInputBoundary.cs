using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CalculateMinimumContribution
{
    public class CalculateContributionInputBoundary : IInputBoundary
    {
        public Guid BarecueIdentifier { get; set; }
    }
}
