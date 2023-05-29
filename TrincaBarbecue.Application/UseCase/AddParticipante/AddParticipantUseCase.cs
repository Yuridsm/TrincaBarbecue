using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.AddParticipante
{
    public class AddParticipantUseCase : IUseCase<InputBoundary, OutputBoundary>
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public AddParticipantUseCase(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public OutputBoundary Execute(InputBoundary inputBoundary)
        {

            return null!;
        }
    }
}
