namespace TrincaBarbecue.SharedKernel.Specification
{
    public abstract class AbstractSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfied(T entity);

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> Not(ISpecification<T> other)
        {
            return new NotSpecification<T>(other);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }
    }
}
