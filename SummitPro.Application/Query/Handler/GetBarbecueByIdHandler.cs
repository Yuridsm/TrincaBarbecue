using SummitPro.Application.Repository;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query.Handler
{
    public class GetBarbecueByIdHandler : IQueryHandler<GetBarbecueByIdQuery, Response>
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public GetBarbecueByIdHandler(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public Task<Response> Handle(GetBarbecueByIdQuery request, CancellationToken cancellationToken)
        {
            var output = _barbecueRepository.Get(request.barbecueIdentifier);

            return Task.FromResult(new Response(output.Identifier, output.Description));
        }
    }
}
