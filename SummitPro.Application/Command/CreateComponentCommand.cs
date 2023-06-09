using MediatR;

namespace SummitPro.Application.Command
{
    public class CreateComponentCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
