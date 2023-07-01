using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.SharedKernel;

public class EntityBase : IEntity<Guid>
{
	public Guid Identifier { get; set; }

	private List<DomainEventBase> _domainEvents = new();
	public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

	protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
	internal void ClearDomainEvent() => _domainEvents.Clear();
}
