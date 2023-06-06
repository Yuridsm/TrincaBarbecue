using Microsoft.AspNetCore.Mvc;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Infrastructure.Http.Controller;
using SummitPro.Infrastructure.DistributedCache;

namespace SummitPro.Web.Endpoints.Barbecue
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
                .SetDistributedCache(new CachedRepository())
                .Handle(inputBoundary)
                .GetIdentifier();

            return Ok(output);
        }
    }
}
