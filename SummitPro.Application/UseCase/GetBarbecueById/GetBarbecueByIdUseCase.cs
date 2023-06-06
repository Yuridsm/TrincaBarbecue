using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.UseCase.GetBarbecueById
{
    public class GetBarbecueByIdUseCase : IUseCaseSinchronous
        .WithInputBoundary<GetBarbecueByIdInputBoundary>
        .WithOutputBoundary<GetBarbecueByIdOutputBoundary>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private ICachedRepository _cachedRepository;

        public GetBarbecueByIdUseCase(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public GetBarbecueByIdUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override GetBarbecueByIdOutputBoundary Execute(GetBarbecueByIdInputBoundary inputBoundary)
        {
            if (_cachedRepository != null)
            {
                var existingbarbecue = _cachedRepository.Get<Barbecue>(inputBoundary.BarbecueIdentifier.ToString());

                if (existingbarbecue == null) throw new ArgumentException("Barbecue does not exist.");

                return new GetBarbecueByIdOutputBoundary
                {
                    BarbecueIdentifier = existingbarbecue.Identifier,
                    Description = existingbarbecue.Description,
                    BeginDateTime = existingbarbecue.BeginDate.ToString(),
                    EndDateTime = existingbarbecue.EndDate.ToString(),
                    AdditionalRemarks = existingbarbecue.AdditionalRemarks,
                    Participants = existingbarbecue.Participants
                };
            }
            else
            {
                var existingbarbecue = _barbecueRepository.Find(o => o.Identifier == inputBoundary.BarbecueIdentifier);

                if (existingbarbecue == null) throw new ArgumentException("Barbecue does not exist.");

                return new GetBarbecueByIdOutputBoundary
                {
                    BarbecueIdentifier = existingbarbecue.Identifier,
                    Description = existingbarbecue.Description,
                    BeginDateTime = existingbarbecue.BeginDate.ToString(),
                    EndDateTime = existingbarbecue.EndDate.ToString(),
                    AdditionalRemarks = existingbarbecue.AdditionalRemarks,
                    Participants = existingbarbecue.Participants
                };
            }
        }
    }
}
