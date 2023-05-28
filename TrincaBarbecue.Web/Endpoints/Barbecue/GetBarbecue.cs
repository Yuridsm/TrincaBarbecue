using Microsoft.AspNetCore.Mvc;
using TrincaBarbecue.Infrastructure.Http.Controllers;

namespace TrincaBarbecue.Web.Endpoints.Barbecue
{
    public class GetBarbecue : EndpointBaseSynchronous
        .WithoutRequest
        .WithActionResult<string>
    {
        private readonly CreateBarbecue _createBarbecue;

        public GetBarbecue(CreateBarbecue createBarbecue)
        {
            _createBarbecue = createBarbecue;
        }

        [HttpGet("/teste", Name = "LunarVim")]
        public override ActionResult<string> Handle()
        {
            return Ok(_createBarbecue.Handle("Description", "28/05/2023 14:30:00", "28/05/2023 16:30:00"));
        }
    }
}
