using TrincaBarbecue.Application.Input;
using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Entity;

namespace TrincaBarbecue.Application.UseCase
{
    public class AddNewBarbecueUseCase
    {
        private readonly IBarbecueRepository<Barbecue> _barbecueRepository;

        public AddNewBarbecueUseCase(IBarbecueRepository<Barbecue> barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public Guid Execute(BarbecueInput input)
        {
            var entity = Barbecue.FactoryMethod(input.Description, input.AdditionalObservations, input.BeginDate, input.EndDate);
            _barbecueRepository.Add(entity);
            return entity.Identifier;
        }
    }
}
