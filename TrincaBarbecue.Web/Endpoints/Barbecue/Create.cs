using Microsoft.AspNetCore.Mvc;
using TrincaBarbecue.Application.UseCase.CreateBarbecue;
using TrincaBarbecue.Infrastructure.Http.Controller;

namespace TrincaBarbecue.Web.Endpoints.Barbecue
{
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

                return Ok(_createBarbecue.Handle(inputBoundary).GetIdentifier());
            }
        }
    }
}
