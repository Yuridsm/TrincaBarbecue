using MediatR;

namespace SummitPro.SharedKernel.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
