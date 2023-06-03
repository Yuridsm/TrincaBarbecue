using TrincaBarbecue.Application.Repository;
using TrincaBarbecue.Core.Aggregate.Barbecue;
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
        private ICachedRepository<Barbecue> _cachedRepository;

        public ListBarbecuesUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public ListBarbecuesUseCase SetDistributedCache(ICachedRepository<Barbecue> cachedRepository)
        {
            _cachedRepository = cachedRepository;
            return this;
        }

        public override ListBarbecuesOutputBoundary Execute()
        {
            var participantsModel = new List<ParticipantModel>();

            if (_cachedRepository == null) return null;

            //var barbecues = _barbecueRepository.GetAll().AsEnumerable();
            var barbecues = _cachedRepository.GetAll().AsEnumerable();

            if (!barbecues.Any()) return null;

            var participants = _participantRepository.GetAll().AsEnumerable();

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
