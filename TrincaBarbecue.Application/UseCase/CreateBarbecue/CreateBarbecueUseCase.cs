using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.Core.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueUseCase : IUseCaseSinchronous
        .WithInputBoundary<CreateInputBoundary>
        .WithOutputBoundary<CreateOutputBoundary>
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public CreateBarbecueUseCase(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public override CreateOutputBoundary Execute(CreateInputBoundary input)
        {
            var entity = Barbecue.FactoryMethod(input.Description, input.AdditionalObservations, input.BeginDate, input.EndDate);
            _barbecueRepository.Add(entity);
            return CreateOutputBoundary.FactoryMethod(entity.Identifier);
        }
    }
}
