using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.SharedKernel.Interfaces;
using TrincaBarbecue.SharedKernel.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.GetByIdBarbecue
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

        public override GetBarbecueByIdOutputBoundary Execute(GetBarbecueByIdInputBoundary inputBoundary)
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
