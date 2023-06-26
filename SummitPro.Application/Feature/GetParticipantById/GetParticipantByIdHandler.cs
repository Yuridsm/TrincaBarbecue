using SummitPro.Application.Model;
using SummitPro.Application.Repository;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.GetParticipantById
{
    public class GetParticipantByIdHandler : IQueryHandler<GetParticipantByIdQuery, GetParticipantByIdQueryModel?>
    {
        private readonly IParticipantRepository _participantRepository;

        public GetParticipantByIdHandler(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<GetParticipantByIdQueryModel?> Handle(GetParticipantByIdQuery request, CancellationToken cancellationToken)
        {
            var existingParticipants = _participantRepository.Get(request.ParticipantIdentifer);

            if (existingParticipants == null) return await Task.FromResult<GetParticipantByIdQueryModel?>(null);

            var participantModel = new ParticipantModel
            {
                Identifier = request.ParticipantIdentifer,
                Name = existingParticipants.Name.Value,
                Username = existingParticipants.Username.Value,
                BringDrink = existingParticipants.BringDrink.ToString(),
                ContributionValue = existingParticipants.ContributionValue.Value,
                Items = existingParticipants.Items
            };

            return await Task.FromResult(new GetParticipantByIdQueryModel(participantModel));
        }
    }
}
