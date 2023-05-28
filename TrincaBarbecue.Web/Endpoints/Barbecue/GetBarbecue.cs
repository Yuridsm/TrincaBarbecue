using Microsoft.AspNetCore.Mvc;
using TrincaBarbecue.Infrastructure.Http.Controllers;

namespace TrincaBarbecue.Web.Endpoints.Barbecue
{
    //[ApiController]
    public abstract class EndpointBase2 : ControllerBase
    {
    }

    [ApiController]
    public class Algo : ControllerBase 
    {
        [HttpGet("/teste")]
        public ActionResult<string> Index()
        {
            return Ok("Yuri Melo");
        }
    }

    public class GetBarbecue //: EndpointBase2
    {
        private readonly CreateBarbecue _createBarbecue;

        public GetBarbecue(CreateBarbecue createBarbecue)
        {
            _createBarbecue = createBarbecue;
        }

        //[HttpGet("/teste", Name = "Products_List")]
        //public ActionResult<string> Handle()
        //{
        //    return Ok(_createBarbecue.Handle("Description", "28/05/2023 14:30:00", "28/05/2023 16:30:00"));
        //}
    }
}
