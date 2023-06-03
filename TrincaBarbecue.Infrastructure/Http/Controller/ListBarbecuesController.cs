using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Application.UseCase.ListBarbecues;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.Infrastructure.DistributedCache;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class ListBarbecuesController
    {
        private readonly ListBarbecuesUseCase _listBarbecuesUseCase;

        public ListBarbecuesController(ListBarbecuesUseCase listBarbecuesUseCase)
        {
            _listBarbecuesUseCase = listBarbecuesUseCase;    
        }

        public ListBarbecuesController SetDistributedCache(CachedRepository<Barbecue> cachedRepository)
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
