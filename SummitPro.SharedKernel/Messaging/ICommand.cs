using MediatR;

namespace SummitPro.SharedKernel.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
