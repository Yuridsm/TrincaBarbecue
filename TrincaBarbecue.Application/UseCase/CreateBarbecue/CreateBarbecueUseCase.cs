using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate;

namespace TrincaBarbecue.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueUseCase
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public CreateBarbecueUseCase(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public OutputBoundary Execute(InputBoundary input)
        {
            var entity = Barbecue.FactoryMethod(input.Description, input.AdditionalObservations, input.BeginDate, input.EndDate);
            _barbecueRepository.Add(entity);
            return OutputBoundary.FactoryMethod(entity.Identifier);
        }
    }
}
