using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.UseCase.CalculateMinimumContribution
{
    public class CalculateContributionInputBoundary : IInputBoundary
    {
        public Guid BarecueIdentifier { get; set; }
    }
}
