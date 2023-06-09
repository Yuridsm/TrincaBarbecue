using MediatR;
using SummitPro.Application.UseCase.CreateComponent;

namespace SummitPro.Application.Query.Handler
{
    public class ListComponentHandler : IRequestHandler<ListComponenteQuery, IEnumerable<CreateComponentOutputBoundary>>
    {
        private readonly IGateway<string> _gateway;

        public ListComponentHandler(IGateway<string> gateway)
        {
            _gateway = gateway;
        }

        public Task<IEnumerable<CreateComponentOutputBoundary>> Handle(ListComponenteQuery request, CancellationToken cancellationToken)
        {
            var output = _gateway.GetAll();

            var foo = from item in output
                      select new CreateComponentOutputBoundary
                      {
                          Name = "Something...",
                          Description = item
                      };

            return Task.FromResult(foo);
        }
    }
}
