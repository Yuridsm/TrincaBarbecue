using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.GetParticipant
{
    public class GetParticipantsUseCase : IUseCaseSinchronous
        .WithInputBoundary<GetParticipantsInputBoundary>
        .WithOutputBoundary<GetParticipantsOutputBoundary>
    {
        private readonly IParticipantRepository _participantRepository;

        public GetParticipantsUseCase(
            IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public override GetParticipantsOutputBoundary Execute(GetParticipantsInputBoundary inputBoundary)
        {
            var existingParticipants = _participantRepository.GetByIdentifiers(inputBoundary.ParticipantIdentifiers);

            if (existingParticipants == null) return new GetParticipantsOutputBoundary();

            var participants = existingParticipants
                .Select(x => new Participant 
                {
                    Identifier = x.Identifier,
                    Name = x.Name.Value,
                    Contribution = x.ContributionValue.Value,
                    BringDrink = x.BringDrink.ToString(),
                    Items = x.Items,
                    Username = x.Username.Value
                });

            return new GetParticipantsOutputBoundary()
            {
                Participants = participants
            };
        }
    }
}
