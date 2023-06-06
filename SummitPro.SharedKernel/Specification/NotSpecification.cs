namespace SummitPro.SharedKernel.Specification
{
    public class NotSpecification<T> : AbstractSpecification<T>
    {
        private ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> specification) : base()
        {
            _specification = specification;
        }

        public override bool IsSatisfied(T entity)
        {
            return _specification.IsSatisfied(entity);
        }
    }

}
