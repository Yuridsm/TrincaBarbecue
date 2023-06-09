using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CreateComponent
{
    public class CreateComponentOutputBoundary : IOutputBoundary
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
