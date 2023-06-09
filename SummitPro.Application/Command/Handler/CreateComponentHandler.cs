using MediatR;

namespace SummitPro.Application.Command.Handler
{
    public class CreateComponentHandler : IRequestHandler<CreateComponentCommand>
    {
        public async Task Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            var id = await Task.FromResult(Guid.NewGuid());

            Console.WriteLine($"The component has successfully created! - {id}");
            Console.WriteLine($"Name - {request.input.Name}");
            Console.WriteLine($"Description - {request.input.Description}");
        }
    }
}
