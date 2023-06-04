using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
using TrincaBarbecue.Core.Aggregate.Participant;
using TrincaBarbecue.SharedKernel.Interfaces;
using TrincaBarbecue.SharedKernel.UseCaseContract;

namespace TrincaBarbecue.Application.UseCase.ListBarbecues
{
    public class ListBarbecuesUseCase : IUseCaseSinchronous
        .WithoutInputBoundary
        .WithOutputBoundary<ListBarbecuesOutputBoundary>
    {

        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;
        private ICachedRepository _cachedRepository;

        public ListBarbecuesUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public ListBarbecuesUseCase SetDistributedCache(ICachedRepository cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override ListBarbecuesOutputBoundary Execute()
        {
            var participants = new List<Participant>();
            var participantsModel = new List<ParticipantModel>();
            var barbecues = new List<Barbecue>();


            if (_cachedRepository == null)
            {
                barbecues.AddRange(_barbecueRepository.GetAll().AsEnumerable());
                if (!barbecues.Any()) return null;
                participants.AddRange(_participantRepository.GetAll().AsEnumerable());
            }
            else
            {
                barbecues.AddRange(_cachedRepository.GetAll<Barbecue>().AsEnumerable());
                participants.AddRange(_cachedRepository.GetAll<Participant>());
            }

            ListBarbecuesOutputBoundary output = new ListBarbecuesOutputBoundary
            {
                Barbecues = barbecues.Select(barbecue => new BarbecueModel
                {
                    barbecueIdentifier = barbecue.Identifier,
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
                        })
                })
            };

            return output;
        }
    }
}
