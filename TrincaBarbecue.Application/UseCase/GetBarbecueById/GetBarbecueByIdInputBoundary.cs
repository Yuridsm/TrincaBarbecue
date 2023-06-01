using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.UseCase.GetByIdBarbecue
{
    public class GetBarbecueByIdInputBoundary : IInputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
    }
}
