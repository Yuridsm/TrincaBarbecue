using MediatR;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Command.Handler
{
    public class CreateComponentHandler : ICommandHandler<CreateComponentCommand, Unit>
    {
        private readonly IGateway<string> _gateway;

        public CreateComponentHandler(IGateway<string> gateway)
        {
            _gateway = gateway;
        }

        public async Task<Unit> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            _gateway.Insert($"{request.input.Name};{request.input.Description}");

            Console.WriteLine($"Name - {request.input.Name}");
            Console.WriteLine($"Description - {request.input.Description}");

            return Unit.Value;
        }
    }
}
