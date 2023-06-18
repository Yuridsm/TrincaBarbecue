using Microsoft.AspNetCore.Mvc;

using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Infrastructure.DistributedCache;
using SummitPro.Infrastructure.Http.Controller;

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
            var inputBoundary = new CreateBarbecueInputBoundary
            {
                Description = input.Description,
                BeginDate = DateTime.Parse(input.BeginDate),
                EndDate = DateTime.Parse(input.EndDate),
                AdditionalObservations = input.AdditionalObservations
            };

            var output = await _createBarbecue
                .SetDistributedCache(new CachedRepository())
                .Handle(inputBoundary);

            return Ok(output.BarbecueIdentifier);
        }
    }
}
