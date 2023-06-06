using SummitPro.Application.Repository;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.UseCase.CalculateMinimumContribution
{
    public class CalculateMinimumContributionUseCase : IUseCaseSinchronous
        .WithInputBoundary<CalculateContributionInputBoundary>
        .WithOutputBoundary<CalculateContributionOutputBoundary>
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IParticipantRepository _participantRepository;

        public CalculateMinimumContributionUseCase(IBarbecueRepository barbecueRepository, IParticipantRepository participantRepository)
        {
            _barbecueRepository = barbecueRepository;
            _participantRepository = participantRepository;
        }

        public override CalculateContributionOutputBoundary Execute(CalculateContributionInputBoundary inputBoundary)
        {
            var barbecue = _barbecueRepository.Get(inputBoundary.BarecueIdentifier);

            int participantsQuantity = barbecue.ParticipantsQuantity();

            var participants = _participantRepository.GetByIdentifiers(barbecue.Participants);

            double total = participants.Sum(o => o.ContributionValue.Value) / participantsQuantity;

            return new CalculateContributionOutputBoundary(total);
        }
    }
}
