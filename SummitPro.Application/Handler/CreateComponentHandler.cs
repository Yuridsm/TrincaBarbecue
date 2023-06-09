using MediatR;
using SummitPro.Application.Command;

namespace SummitPro.Application.Handler
{
    public class CreateComponentHandler : IRequestHandler<CreateComponentCommand, Guid>
    {
        public Task<Guid> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            
            Console.WriteLine($"The component has successfully created! - {id}");

            return Task.FromResult(id);
        }
    }
}
