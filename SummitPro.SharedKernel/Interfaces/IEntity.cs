namespace SummitPro.SharedKernel.Interfaces
{
    public interface IEntity<TId>
    {
        TId Identifier { get; }
    }
}
