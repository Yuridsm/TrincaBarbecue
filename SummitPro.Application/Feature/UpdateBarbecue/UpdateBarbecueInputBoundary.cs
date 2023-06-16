using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.UpdateBarbecue
{
    public class UpdateBarbecueInputBoundary : IInputBoundary
    {
        public Guid BarbecueIdentifier { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> AdditionalMarks { get; set; } = new List<string>();
    }
}
