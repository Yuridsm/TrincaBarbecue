namespace SummitPro.SharedKernel.Interfaces;

public interface IEntity<out TId>
{
	TId Identifier { get; }
}
