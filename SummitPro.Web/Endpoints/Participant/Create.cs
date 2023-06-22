using Microsoft.AspNetCore.Mvc;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.AddParticipante;
using SummitPro.Application.UseCase.BindParticipant;

namespace SummitPro.Web.Endpoints.Participant
{
    public class Create : EndpointBaseSynchronous
        .WithRequest<AddParticipantInputBoundary>
        .WithActionResult<AddParticipantOutputBoundary>
    {
        private readonly IAddParticipantUseCase _addParticipantUseCase;
        private readonly IBindParticipantUseCase _bindParticipantUseCase;

        public Create(IAddParticipantUseCase addParticipantUseCase, IBindParticipantUseCase bindParticipantUseCase)
        {
            _addParticipantUseCase = addParticipantUseCase;
            _bindParticipantUseCase = bindParticipantUseCase;
        }

        [HttpPost("/Barbecue/Participant")]
        public override ActionResult<AddParticipantOutputBoundary> Handle([FromBody] AddParticipantInputBoundary request)
        {
            var output = _addParticipantUseCase.Execute(request);

            _bindParticipantUseCase
                .Execute(new BindParticipantInputBoundary
                {
                    BarbecueIdentifier = request.BarbecueIdentifier,
                    ParticipantIdentifier = output.ParticipantIdentifier,
                });

            return Ok(output);
        }
    }
}
