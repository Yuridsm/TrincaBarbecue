using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreatebarbecueOutputBoundary : IOutputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }

        public CreatebarbecueOutputBoundary(Guid barbecueIdentifier)
        {
            BarbecueIdentifier = barbecueIdentifier;
        }
    }
}
