using Microsoft.AspNetCore.Mvc;
using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Infrastructure.Http.Controller;

namespace TrincaBarbecue.Web.Endpoints.Barbecue
{
    public class Get : EndpointBaseSynchronous
        .WithRequest<Guid>
        .WithActionResult<GetResponse>
    {
        private readonly GetbarbecueByIdController _getbarbecueByIdController;

        public Get(GetbarbecueByIdController getbarbecueByIdController)
        {
            _getbarbecueByIdController = getbarbecueByIdController;
        }

        [HttpGet("/Barbecue/{identifier:Guid}")]
        public override ActionResult<GetResponse> Handle([FromRoute] Guid identifier)
        {
            var inputBoundary = new GetBarbecueByIdInputBoundary
            {
                BarbecueIdentifier = identifier
            };

            var outputBoundary = _getbarbecueByIdController.Handle(inputBoundary);

            return Ok(new GetResponse
            {
                Identifier = outputBoundary.BarbecueIdentifier,
                Description = outputBoundary.Description,
                BeginDateTime = outputBoundary.BeginDateTime,
                EndDateTime = outputBoundary.EndDateTime,
                AdditionalRemarks = outputBoundary.AdditionalRemarks,
                Participants = outputBoundary.Participants
            });
        }
    }
}
