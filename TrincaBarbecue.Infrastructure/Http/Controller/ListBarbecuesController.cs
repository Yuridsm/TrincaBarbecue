using TrincaBarbecue.Application.UseCase.ListBarbecues;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class ListBarbecuesController
    {
        private readonly ListBarbecuesUseCase _listBarbecuesUseCase;

        public ListBarbecuesController(ListBarbecuesUseCase listBarbecuesUseCase)
        {
            _listBarbecuesUseCase = listBarbecuesUseCase;    
        }

        public ListBarbecuesOutputBoundary Handle()
        {
            return _listBarbecuesUseCase.Execute();
        }
    }
}
