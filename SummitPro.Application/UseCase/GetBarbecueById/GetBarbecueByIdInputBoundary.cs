using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.GetBarbecueById
{
    public class GetBarbecueByIdInputBoundary : IInputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
    }
}
