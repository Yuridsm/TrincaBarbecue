using Microsoft.AspNetCore.Mvc;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.CreateBarbecue;

namespace SummitPro.Web.Endpoints.Barbecue
{
    public class Create : EndpointBaseAssynchronous
        .WithRequest<CreateRequest>
        .WithActionResult<string>
    {
        private readonly ICreateBarbecueUseCase _createBarbecueUseCase;

        public Create(ICreateBarbecueUseCase createBarbecueUseCase)
        {
            _createBarbecueUseCase = createBarbecueUseCase;
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

            var output = await _createBarbecueUseCase
                .Execute(inputBoundary);

            return Ok(output.BarbecueIdentifier);
        }
    }
}
