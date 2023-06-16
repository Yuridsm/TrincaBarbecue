using MediatR;

using SummitPro.Application.Interface;
using SummitPro.Application.Model;
using SummitPro.Application.Query;

namespace SummitPro.Application.UseCase.GetParticipant
{
    public class GetParticipantByIdUseCase : IGetParticipantByIdUseCase
    {
        private readonly IMediator _mediator;

        public GetParticipantByIdUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public override async Task<GetParticipantByIdOutputBoundary> Execute(GetParticipantByIdInputBoundary inputBoundary)
        {
            var query = new GetParticipantByIdQuery(inputBoundary.ParticipantIdentifier);

            var queryModel = await _mediator.Send(query);

            return new GetParticipantByIdOutputBoundary
            {
                Participant = new ParticipantModel
                {
                    Name = queryModel.model.Name,
                    Username = queryModel.model.Username,
                    BringDrink = queryModel.model.BringDrink,
                    ContributionValue = queryModel.model.ContributionValue,
                    Identifier = queryModel.model.Identifier,
                    Items = queryModel.model.Items
                }
            };
        }
    }
}
