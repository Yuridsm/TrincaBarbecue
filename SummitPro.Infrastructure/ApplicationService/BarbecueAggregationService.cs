using SummitPro.Application.ApplicationService;
using SummitPro.Application.Model;
using SummitPro.Application.Repository;

namespace SummitPro.Infrastructure.ApplicationService
{
    public class BarbecueAggregationService : IBarbecueAggregationService
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;

        public BarbecueAggregationService(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public BarbecueModel? Aggregate(Guid barbecueIdentifier)
        {
            var barbecue = _barbecueRepository.Get(barbecueIdentifier);

            if (barbecue == null) return null;

            var barbecueModel = new BarbecueModelBuilder()
                .AddBarbecueIdentifier(barbecueIdentifier)
                .AddBeginDate(barbecue.BeginDate.ToString())
                .AddEndDate(barbecue.EndDate.ToString())
                .AddAdditionalRemarks(barbecue.AdditionalRemarks)
                .AddDescription(barbecue.Description);

            var participants = _participantRepository.GetByIdentifiers(barbecue.Participants);

            if (participants == null || participants.Count() == 0) return barbecueModel.Build();

            foreach (var participant in participants)
            {
                var participantModel = new ParticipantModel
                {
                    Identifier = participant.Identifier,
                    Name = participant.Name.Value,
                    Username = participant.Username.Value,
                    BringDrink = participant.BringDrink.ToString(),
                    ContributionValue = participant.ContributionValue.Value,
                    Items = participant.Items
                };

                barbecueModel.AddParticipant(participantModel);
            }

            return barbecueModel.Build();
        }
    }
}
