using AutoMapper;
using MediatR;
using SummitPro.Application.Interface;
using SummitPro.Application.OutputBoundary;
using SummitPro.Application.Query;
using SummitPro.Application.Repository;

namespace SummitPro.Application.UseCase.GetBarbecueById
{
    public class GetBarbecueByIdUseCase : IGetBarbecueByIdUseCase
    {
        private readonly IBarbecueRepository _barbecueRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetBarbecueByIdUseCase(IBarbecueRepository barbecueRepository, IMapper mapper, IMediator mediator)
        {
            _barbecueRepository = barbecueRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task<GetBarbecueByIdOutputBoundary> Execute(GetBarbecueByIdInputBoundary inputBoundary)
        {
            var query = new GetBarbecueByIdQuery(inputBoundary.BarbecueIdentifier);

            GetBarbecueByIdQueryModel model = await _mediator.Send(query);

            if (model == null) throw new ArgumentException("Barbecue does not exist.");

            return new GetBarbecueByIdOutputBoundary
            {
                BarbecueIdentifier = model.BarbecueIdentifier,
                Description = model.Description,
                BeginDateTime = model.BeginDate.ToString(),
                EndDateTime = model.EndDate.ToString(),
                AdditionalRemarks = model.AdditionalRemarks,
                Participants = model.Participants is not null ? model.Participants.Select(o => o.Identifier) : new List<Guid>(0)
            };
        }
    }
}
