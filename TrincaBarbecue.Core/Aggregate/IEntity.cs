namespace TrincaBarbecue.Core.Aggregate
{
    public interface IEntity<TId>
    {
        TId Identifier { get; }
    }
}
