using Microsoft.AspNetCore.Mvc;
using TrincaBarbecue.Web.Controllers;

namespace TrincaBarbecue.Web.Endpoints.Barbecue
{
    public class Get : EndpointBaseSynchronous
        .WithoutRequest
        .WithActionResult<GetResult>
    {
        private readonly CreateBarbecueController _createBarbecue;

        public Get(CreateBarbecueController createBarbecue)
        {
            _createBarbecue = createBarbecue;
        }

        [HttpGet("/Barbecue")]
        public override ActionResult<GetResult> Handle()
        {
            return Ok(_createBarbecue.Handle("Description", "28/05/2023 14:30:00", "28/05/2023 16:30:00"));
        }
    }
}
