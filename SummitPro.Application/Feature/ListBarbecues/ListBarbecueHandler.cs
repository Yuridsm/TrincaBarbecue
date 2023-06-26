using SummitPro.Application.Model;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;
using SummitPro.Core.Aggregate.Participant;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.ListBarbecues
{
    public class ListBarbecueHandler : IQueryHandler<ListBarbecueQuery, ListBarbecuesQueryModel?>
    {
        private IBarbecueRepository _barbecueRepository;
        private IParticipantRepository _participantRepository;

        public ListBarbecueHandler(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public async Task<ListBarbecuesQueryModel?> Handle(ListBarbecueQuery request, CancellationToken cancellationToken)
        {
            var barbecues = new List<Barbecue>();
            var participants = new List<Participant>();
            var participantsModel = new List<ParticipantModel>();

            barbecues.AddRange(_barbecueRepository.GetAll().AsEnumerable());

            if (!barbecues.Any()) return await Task.FromResult<ListBarbecuesQueryModel?>(null);

            participants.AddRange(_participantRepository.GetAll().AsEnumerable());

            ListBarbecuesQueryModel output = new ListBarbecuesQueryModel
            {
                Barbecues = barbecues.Select(barbecue => new BarbecueModel
                {
                    BarbecueIdentifier = barbecue.Identifier,
                    Description = barbecue.Description,
                    BeginDate = barbecue.BeginDate.ToString(),
                    EndDate = barbecue.EndDate.ToString(),
                    AdditionalRemarks = barbecue.AdditionalRemarks,
                    Participants = participants
                        .Where(p => barbecue.Participants.Contains(p.Identifier))
                        .Select(o => new ParticipantModel
                        {
                            Identifier = o.Identifier,
                            BringDrink = o.BringDrink.ToString(),
                            ContributionValue = o.ContributionValue.Value,
                            Items = o.Items,
                            Name = o.Name.Value,
                            Username = o.Username.Value
                        }).ToList()
                })
            };

            return await Task.FromResult(output);
        }
    }
}
