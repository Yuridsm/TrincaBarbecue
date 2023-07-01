using SummitPro.SharedKernel;

namespace SummitPro.Core.Event;

public class CreatedBarbecueEvent : DomainEventBase
{
	public string Name { get; init; }
	public Guid BarbecueIdentifier { get; init; }

	public CreatedBarbecueEvent(string name, Guid barbecueIdentifier)
	{
		Name = name;
		BarbecueIdentifier = barbecueIdentifier;
	}
}
