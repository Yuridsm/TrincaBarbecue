import { AbstractSpecification } from "./AbstractionSpecification";
import { ISpecification } from "./ISpecification";

export class AndSpecification<T> extends AbstractSpecification<T> {
    private left: ISpecification<T>;
    private right: ISpecification<T>;

    constructor(left: ISpecification<T>, right: ISpecification<T>) {
        super();
        this.left = left;
        this.right = right;
    }

    isSatisfiedBy(item: T): boolean {
        return this.left.isSatisfiedBy(item) && this.right.isSatisfiedBy(item);
    }
}