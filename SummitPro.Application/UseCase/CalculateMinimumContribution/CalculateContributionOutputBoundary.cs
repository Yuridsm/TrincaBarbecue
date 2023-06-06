using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CalculateMinimumContribution
{
    public class CalculateContributionOutputBoundary : IOutputBoundary
    {
        public double Value { get; set; }

        public CalculateContributionOutputBoundary(double value)
        {
            Value = value;
        }
    }
}
