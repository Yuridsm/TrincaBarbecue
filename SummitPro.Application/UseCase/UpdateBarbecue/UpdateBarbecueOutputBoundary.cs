using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.UpdateBarbecue
{
    public class UpdateBarbecueOutputBoundary : IOutputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
    }
}
