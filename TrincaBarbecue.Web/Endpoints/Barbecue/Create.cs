using Microsoft.AspNetCore.Mvc;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Infrastructure.DistributedCache;
using TrincaBarbecue.Infrastructure.Http.Controller;

namespace TrincaBarbecue.Web.Endpoints.Barbecue
{
    public class Create : EndpointBaseSynchronous
        .WithRequest<CreateRequest>
        .WithActionResult<string>
    {
        private readonly CreateBarbecueController _createBarbecue;

        public Create(CreateBarbecueController createBarbecue)
        {
            _createBarbecue = createBarbecue;
        }

        [HttpPost("/Barbecue")]
        public override ActionResult<string> Handle([FromBody] CreateRequest input)
        {
            var inputBoundary = CreateInputBoundary
                .FactoryMethod(
                    input.Description,
                    input.AdditionalObservations,
                    DateTime.Parse(input.BeginDate),
                    DateTime.Parse(input.EndDate));

            var output = _createBarbecue
                .SetDistributedCache(new CachedRepository<Core.Aggregate.Barbecue.Barbecue>())
                .Handle(inputBoundary)
                .GetIdentifier();

            return Ok(output);
        }
    }
}
