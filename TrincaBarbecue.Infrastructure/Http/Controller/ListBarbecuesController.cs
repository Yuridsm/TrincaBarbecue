using TrincaBarbecue.Application.UseCase.ListBarbecues;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class ListBarbecuesController
    {
        private readonly ListBarbecuesUseCase _listBarbecuesUseCase;

        public ListBarbecuesController(ListBarbecuesUseCase listBarbecuesUseCase)
        {
            _listBarbecuesUseCase = listBarbecuesUseCase;    
        }

        public ListBarbecuesController SetDistributedCache(ICachedRepository cachedRepository)
        {
            _listBarbecuesUseCase
                .SetDistributedCache(cachedRepository);

            return this;
        }

        public ListBarbecuesOutputBoundary Handle()
        {
            return _listBarbecuesUseCase.Execute();
        }
    }
}
