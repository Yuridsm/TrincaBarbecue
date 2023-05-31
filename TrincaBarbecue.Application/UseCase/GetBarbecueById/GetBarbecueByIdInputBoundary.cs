using TrincaBarbecue.Core;

namespace TrincaBarbecue.Application.UseCase.GetByIdBarbecue
{
    public class GetBarbecueByIdInputBoundary : IInputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
    }
}
