using MediatR;

namespace SummitPro.SharedKernel;

public abstract class DomainEventBase : INotification
{
	public DateTime DateOccurred { get; protected init; } = DateTime.UtcNow;
}
