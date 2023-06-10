using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query.Handler
{
    public class GetBarbecueByIdHandler : IQueryHandler<GetBarbecueByIdQuery, Response>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly ICachedRepository _cachedRepository;

        public GetBarbecueByIdHandler(IBarbecueRepository barbecueRepository, ICachedRepository cachedRepository)
        {
            _barbecueRepository = barbecueRepository;
            _cachedRepository = cachedRepository;
        }

        public Task<Response> Handle(GetBarbecueByIdQuery request, CancellationToken cancellationToken)
        {
            Barbecue? output = default;

            if (_cachedRepository is not null && request is not null)
                output = _cachedRepository.Get<Barbecue>(request.barbecueIdentifier.ToString());
            else if (request is not null)
                output = _barbecueRepository.Get(request.barbecueIdentifier);

            return Task.FromResult(new Response(output.Identifier, output.Description));
        }
    }
}
