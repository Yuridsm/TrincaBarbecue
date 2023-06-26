using Microsoft.AspNetCore.Mvc;
using SummitPro.Application.ApplicationService;
using SummitPro.Application.Model;

namespace SummitPro.Web.Endpoints.Barbecue
{
    public class Get : EndpointBaseAssynchronous
        .WithRequest<Guid>
        .WithActionResult<BarbecueModel>
    {
        private readonly IBarbecueAggregationService _barbecueAggregationService;

        public Get(IBarbecueAggregationService barbecueAggregationService)
        {
            _barbecueAggregationService = barbecueAggregationService;
        }

        [HttpGet("/Barbecue/{identifier:Guid}")]
        public override async Task<ActionResult<BarbecueModel>> Handle([FromRoute] Guid identifier)
        {
            var outputBoundary = await Task.FromResult(_barbecueAggregationService.Aggregate(identifier));

            return Ok(outputBoundary);
        }
    }
}
