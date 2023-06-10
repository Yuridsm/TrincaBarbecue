using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueOutputBoundary : IOutputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }

        public CreateBarbecueOutputBoundary(Guid barbecueIdentifier)
        {
            BarbecueIdentifier = barbecueIdentifier;
        }
    }
}
