//using Microsoft.AspNetCore.Mvc;
//using SummitPro.Application.UseCase.AddParticipante;
//using SummitPro.Infrastructure.Http.Controller;
//using SummitPro.Application.UseCase.BindParticipant;
//using SummitPro.Infrastructure.DistributedCache;

//namespace SummitPro.Web.Endpoints.Participant
//{
//    public class Create : EndpointBaseSynchronous
//        .WithRequest<AddParticipantInputBoundary>
//        .WithActionResult<AddParticipantOutputBoundary>
//    {
//        private readonly AddParticipantController _addParticipantController;
//        private readonly BindParticipantTobarbecueController _bindParticipantController;

//        public Create(AddParticipantController addParticipantController, BindParticipantTobarbecueController bindParticipantController)
//        {
//            _addParticipantController = addParticipantController;
//            _bindParticipantController = bindParticipantController;
//        }

//        [HttpPost("/Barbecue/Participant")]
//        public override ActionResult<AddParticipantOutputBoundary> Handle([FromBody] AddParticipantInputBoundary request)
//        {
//            var output = _addParticipantController
//                .SetDistributedCache(new CachedRepository())
//                .Handle(request);

//            _bindParticipantController
//                .SetDistributedCache(new CachedRepository())
//                .Handle(new BindParticipantInputBoundary
//                {
//                    BarbecueIdentifier = request.BarbecueIdentifier,
//                    ParticipantIdentifier = output.ParticipantIdentifier,
//                });

//            return Ok(output);
//        }
//    }
//}
