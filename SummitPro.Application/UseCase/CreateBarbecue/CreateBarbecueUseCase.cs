using AutoMapper;
using MediatR;

using SummitPro.Application.Command;
using SummitPro.Application.CommandModel;
using SummitPro.Application.Interface;
using SummitPro.Core.Aggregate.Barbecue;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueUseCase : ICreateBarbecueUseCase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateBarbecueUseCase(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<CreateBarbecueOutputBoundary> Execute(CreateBarbecueInputBoundary input)
        {
            var entity = _mapper.Map<Barbecue>(input);

            var commandModel = _mapper.Map<Barbecue, CreateBarbecueCommandModel>(entity);

            var createBarbecueCommand = new CreateBarbecueCommand(commandModel);

            await _mediator.Send(createBarbecueCommand);

            return new CreateBarbecueOutputBoundary(entity.Identifier);
        }
    }
}
