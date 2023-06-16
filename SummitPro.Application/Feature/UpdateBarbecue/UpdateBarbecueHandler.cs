using MediatR;
using SummitPro.Application.Repository;
using SummitPro.SharedKernel.Messaging;

namespace SummitPro.Application.Feature.UpdateBarbecue
{
    public class UpdateBarbecueHandler : ICommandHandler<UpdateBarbecueCommand, Unit>
    {
        private readonly IBarbecueRepository _barbecueRepository;

        public UpdateBarbecueHandler(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public Task<Unit> Handle(UpdateBarbecueCommand request, CancellationToken cancellationToken)
        {
            if (request is null || request.model is null) return Task.FromResult(new Unit());

            var barbecue = _barbecueRepository.Get(request.model.BarbecueIdentifier);

            if (barbecue == null) return Task.FromResult(new Unit());

            barbecue.AddDescription(request.model.Description ?? barbecue.Description);

            barbecue.Reschedule(
                request.model.BeginDate ?? barbecue.BeginDate,
                request.model.EndDate ?? barbecue.EndDate);

            if (request.model.AdditionalMarks is not null && request.model.AdditionalMarks.Any())
                foreach (var remark in request.model.AdditionalMarks)
                    barbecue.AddAdditionalRemark(remark);

            _barbecueRepository.Update(barbecue);

            return Task.FromResult(new Unit());
        }
    }
}
