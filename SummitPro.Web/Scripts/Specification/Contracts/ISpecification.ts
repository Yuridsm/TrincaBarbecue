export default interface ISpecification<T> {
    isSatisfiedBy(element: T): boolean;
}
