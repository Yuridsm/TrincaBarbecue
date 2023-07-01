using MediatR;

namespace SummitPro.SharedKernel.Messaging;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
	where TCommand : ICommand<TResponse>
{
}
