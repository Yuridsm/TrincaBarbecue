using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.SharedKernel.Interfaces;
using TrincaBarbecue.SharedKernel.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueUseCase : IUseCaseSinchronous
        .WithInputBoundary<CreateInputBoundary>
        .WithOutputBoundary<CreateOutputBoundary>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private ICachedRepository<Barbecue> _cachedRepository;

        public CreateBarbecueUseCase(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public CreateBarbecueUseCase SetDistributedCache(ICachedRepository<Barbecue> cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override CreateOutputBoundary Execute(CreateInputBoundary input)
        {
            var entity = Barbecue.FactoryMethod(input.Description, input.AdditionalObservations, input.BeginDate, input.EndDate);
            
            _barbecueRepository.Add(entity);

            if (_cachedRepository != null) _cachedRepository.Set(entity.Identifier.ToString(), entity);

            return CreateOutputBoundary.FactoryMethod(entity.Identifier);
        }
    }
}
