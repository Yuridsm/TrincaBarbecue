using SummitPro.Application.OutputBoundary;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Query.Handler
{
    public class GetBarbecueByIdHandler : IQueryHandler<GetBarbecueByIdQuery, GetBarbecueByIdQueryModel>
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public GetBarbecueByIdHandler(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public Task<GetBarbecueByIdQueryModel> Handle(GetBarbecueByIdQuery request, CancellationToken cancellationToken)
        {
            Barbecue? output = _barbecueRepository.Get(request.BarbecueIdentifier);

            if (output == null) return Task.FromResult(new GetBarbecueByIdQueryModel());

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
