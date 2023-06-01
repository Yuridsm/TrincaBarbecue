using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Application.UseCase.GetByIdBarbecue
{
    public class GetBarbecueByIdOutputBoundary : IOutputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
        public string Description { get; set; }  = string.Empty;
        public string BeginDateTime { get; set; } = string.Empty;
        public string EndDateTime { get; set; } = string.Empty;
        public IEnumerable<string> AdditionalRemarks { get; set; }
        public IEnumerable<Guid> Participants { get; set; }
    }
}
