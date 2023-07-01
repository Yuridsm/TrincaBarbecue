namespace SummitPro.SharedKernel.Specification;

public interface ISpecification<T>
{
	bool IsSatisfied(T entity);
	ISpecification<T> And(ISpecification<T> other);
	ISpecification<T> Or(ISpecification<T> other);
	ISpecification<T> Not(ISpecification<T> other);
}
