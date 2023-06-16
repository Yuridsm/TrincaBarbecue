using MediatR;

using SummitPro.Application.Feature.ListBarbecues;
using SummitPro.Application.Interface;

namespace SummitPro.Application.UseCase.ListBarbecues
{
    public class ListBarbecuesUseCase : IListBarbecuesUseCase
    {
        private readonly IMediator _mediator;

        public ListBarbecuesUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public override async Task<ListBarbecuesOutputBoundary> Execute()
        {
            var query = new ListBarbecueQuery();

            ListBarbecuesQueryModel queryModel = await _mediator.Send(query);

            return new ListBarbecuesOutputBoundary
            {
                Barbecues = queryModel.Barbecues
            };
        }
    }
}
