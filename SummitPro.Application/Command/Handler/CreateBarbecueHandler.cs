using MediatR;
using SummitPro.Application.Repository;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Command.Handler
{
    public class CreateBarbecueHandler : ICommandHandler<CreateBarbecueCommand, Unit>
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public CreateBarbecueHandler(IBarbecueRepository barbecueRepository)
        {
            Console.WriteLine($"I am in {nameof(CreateBarbecueCommand)} with {_barbecueRepository}");
            _barbecueRepository = barbecueRepository;
            Console.WriteLine($"I am in {nameof(CreateBarbecueCommand)} with {_barbecueRepository}");
        }

        public Task<Unit> Handle(CreateBarbecueCommand request, CancellationToken cancellationToken)
        {
            _barbecueRepository.Add(request.input);

            return Task.FromResult(Unit.Value);
        }
    }
}
