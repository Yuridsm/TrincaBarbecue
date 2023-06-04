using TrincaBarbecue.Application.UseCase.GetByIdBarbecue;
using TrincaBarbecue.Application.UseCase.GetParticipant;
using TrincaBarbecue.Infrastructure.DistributedCache;
using TrincaBarbecue.Infrastructure.Http.Response;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Infrastructure.Http.Controller
{
    public class GetbarbecueByIdController
    {
        private readonly GetBarbecueByIdUseCase _getBarbecueByIdUseCase;
        private readonly GetParticipantsUseCase _getParticipantsUseCase;

        public GetbarbecueByIdController(
            GetBarbecueByIdUseCase getBarbecueByIdUseCase,
            GetParticipantsUseCase getParticipantsUseCase
            )
        {
            _getBarbecueByIdUseCase = getBarbecueByIdUseCase;
            _getParticipantsUseCase = getParticipantsUseCase;
        }

        public GetbarbecueByIdController SetDistributedCache(ICachedRepository cachedRepository)
        {
            _getBarbecueByIdUseCase.SetDistributedCache(cachedRepository);
            _getParticipantsUseCase.SetDistributedCache(cachedRepository);

            return this;
        }

        public GetBarbecueByIdResponse Handle(GetBarbecueByIdInputBoundary input)
        {
            var barbecue = _getBarbecueByIdUseCase
                .SetDistributedCache(new CachedRepository())
                .Execute(input);

            if (barbecue == null) throw new ArgumentNullException("There is no barbecue.");

            var result = _getParticipantsUseCase
                .SetDistributedCache(new CachedRepository())
                .Execute(new GetParticipantsInputBoundary
                {
                    ParticipantIdentifiers = barbecue.Participants
                });

            var response = new GetBarbecueByIdResponse()
            {
                AdditionalRemarks = barbecue.AdditionalRemarks,
                BarbecueIdentifier = barbecue.BarbecueIdentifier,
                BeginDateTime = barbecue.BeginDateTime,
                Description = barbecue.Description,
                EndDateTime = barbecue.EndDateTime
            };

            if (result == null) return response;

            var participants = new List<ParticipantOutputBoundary>();

            foreach (var participant in result.Participants)
                participants.Add(participant);

            response.Participants = participants;

            return response;
        }
    }
}
