//using SummitPro.Application.UseCase.AddParticipante;
//using SummitPro.SharedKernel.Interfaces;

//namespace SummitPro.Infrastructure.Http.Controller
//{
//    public class AddParticipantController
//    {
//        private readonly AddParticipantUseCase _addParticipantUseCase;

//        public AddParticipantController(AddParticipantUseCase addParticipantUseCase)
//        {
//            _addParticipantUseCase = addParticipantUseCase;
//        }

//        public AddParticipantController SetDistributedCache(ICachedRepository cachedRepository)
//        {
//            _addParticipantUseCase
//                .SetDistributedCache(cachedRepository);

//            return this;
//        }

//        public AddParticipantOutputBoundary Handle(AddParticipantInputBoundary input)
//        {
//            return _addParticipantUseCase
//                .Execute(input);
//        }
//    }
//}
