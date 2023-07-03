using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.UseCaseContract;

namespace SummitPro.Application.Interface;

public abstract class ICreateBarbecueUseCase : IUseCaseAsynchronous
	.WithInputBoundary<CreateBarbecueInputBoundary>
	.WithOutputBoundary<CreateBarbecueOutputBoundary>
{
	protected ICachedRepository _cachedRepository = null!;

	public ICreateBarbecueUseCase SetDistributedCache(ICachedRepository cachedRepository)
	{
		_cachedRepository = cachedRepository;
		return this;
	}
}
