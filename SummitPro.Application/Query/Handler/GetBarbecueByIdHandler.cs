using SummitPro.Application.OutputBoundary;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query.Handler
{
    public class GetBarbecueByIdHandler : IQueryHandler<GetBarbecueByIdQuery, GetBarbecueByIdQueryModel>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly ICachedRepository _cachedRepository;

        public GetBarbecueByIdHandler(IBarbecueRepository barbecueRepository, ICachedRepository cachedRepository)
        {
            _barbecueRepository = barbecueRepository;
            _cachedRepository = cachedRepository;
        }

        public Task<GetBarbecueByIdQueryModel> Handle(GetBarbecueByIdQuery request, CancellationToken cancellationToken)
        {
            Barbecue? output = default;

            if (_cachedRepository is not null && request is not null)
                output = _cachedRepository.Get<Barbecue>(request.BarbecueIdentifier.ToString());
            else if (request is not null)
                output = _barbecueRepository.Get(request.BarbecueIdentifier);

            return Task.FromResult(new GetBarbecueByIdQueryModel
            {
                BarbecueIdentifier = output.Identifier,
                BeginDate = output.BeginDate,
                EndDate = output.EndDate,
                Description = output.Description,
                AdditionalRemarks = output.AdditionalRemarks
            });
        }
    }
}
