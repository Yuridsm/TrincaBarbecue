using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueInputBoundary : IInputBoundary
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> AdditionalObservations { get; set; } = new List<string>();
    }
}
