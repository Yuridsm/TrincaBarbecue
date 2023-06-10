using SummitPro.Application.OutputBoundary;
using SummitPro.Application.UseCase.ListBarbecues;
using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Infrastructure.Http.Controller
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

        public ListBarbecuesQueryModel Handle()
        {
            return _listBarbecuesUseCase.Execute();
        }
    }
}
