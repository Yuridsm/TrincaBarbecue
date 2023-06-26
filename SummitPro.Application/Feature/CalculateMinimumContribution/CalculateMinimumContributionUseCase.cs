using MediatR;

using SummitPro.Application.Feature.GetParticipantById;
using SummitPro.Application.Interface;
using SummitPro.Application.Model;
using SummitPro.Application.Repository;
using SummitPro.Core.Aggregate.Barbecue;

namespace SummitPro.Application.UseCase.CalculateMinimumContribution
{
    public class CalculateMinimumContributionUseCase : ICalculateMinimumContributionUseCase
    {
        private readonly IMediator _mediator;
        private readonly IBarbecueRepository _barbecueRepository;

        public CalculateMinimumContributionUseCase(IMediator mediator, IBarbecueRepository barbecueRepository)
        {
            _mediator = mediator;
            _barbecueRepository = barbecueRepository;
        }

        public override async Task<CalculateContributionOutputBoundary> Execute(CalculateContributionInputBoundary inputBoundary)
        {
            Barbecue? barbecue = _barbecueRepository.Get(inputBoundary.BarecueIdentifier);

            if (barbecue is null) throw new ArgumentNullException("Barbecue does not exist");
            
            ICollection<ParticipantModel> participants = new List<ParticipantModel>();
            double contributionValue = 00.00f;

            foreach (var item in barbecue.Participants)
            {
                var participant = await _mediator.Send(new GetParticipantByIdQuery(item));
                
                if (participant is null) continue;

                contributionValue += participant.model.ContributionValue;
            }

            double total = contributionValue / barbecue.ParticipantsQuantity();

            return new CalculateContributionOutputBoundary(contributionValue);
        }
    }
}
