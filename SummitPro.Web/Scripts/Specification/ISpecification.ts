export interface ISpecification<T> {
    isSatisfiedBy(element: T): boolean;
    and(other: ISpecification<T>): ISpecification<T>;
    or(other: ISpecification<T>): ISpecification<T>;
    not(other: ISpecification<T>): ISpecification<T>;
}
