import ISpecification from "../Contracts/ISpecification";

export default class AndSpecification<T> implements ISpecification<T> {
    private left: ISpecification<T>;
    private right: ISpecification<T>;

    constructor(left: ISpecification<T>, right: ISpecification<T>) {
        this.left = left;
        this.right = right;
    }

    isSatisfiedBy(item: T): boolean {
        return this.left.isSatisfiedBy(item) && this.right.isSatisfiedBy(item);
    }
}
