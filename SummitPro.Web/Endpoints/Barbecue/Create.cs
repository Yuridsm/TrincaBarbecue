using Microsoft.AspNetCore.Mvc;
using SummitPro.Infrastructure.Http.Controller;
using SummitPro.Infrastructure.DistributedCache;
using SummitPro.Application.UseCase.CreateBarbecue;

namespace SummitPro.Web.Endpoints.Barbecue
{
    public class Create : EndpointBaseAssynchronous
        .WithRequest<CreateRequest>
        .WithActionResult<string>
    {
        private readonly CreateBarbecueController _createBarbecue;

        public Create(CreateBarbecueController createBarbecue)
        {
            _createBarbecue = createBarbecue;
        }

        [HttpPost("/Barbecue")]
        public override async Task<ActionResult<string>> Handle([FromBody] CreateRequest input)
        {
            var inputBoundary = CreateBarbecueInputBoundary
                .FactoryMethod(
                    input.Description,
                    input.AdditionalObservations,
                    DateTime.Parse(input.BeginDate),
                    DateTime.Parse(input.EndDate));

            var output = await _createBarbecue
                .SetDistributedCache(new CachedRepository())
                .Handle(inputBoundary);

            return Ok(output.BarbecueIdentifier);
        }
    }
}
