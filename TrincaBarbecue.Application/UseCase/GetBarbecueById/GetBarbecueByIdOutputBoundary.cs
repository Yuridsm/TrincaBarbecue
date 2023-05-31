using TrincaBarbecue.Core;

namespace TrincaBarbecue.Application.UseCase.GetByIdBarbecue
{
    public class GetBarbecueByIdOutputBoundary : IOutputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; }  = string.Empty;
    }
}
