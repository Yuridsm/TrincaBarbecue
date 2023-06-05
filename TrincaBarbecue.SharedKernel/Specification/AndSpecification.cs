namespace TrincaBarbecue.SharedKernel.Specification
{
    public class AndSpecification<T> : AbstractSpecification<T>
    {
        private ISpecification<T> _left;
        private ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base()
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfied(T entity)
        {
            return _left.IsSatisfied(entity) && _right.IsSatisfied(entity);
        }
    }
}
