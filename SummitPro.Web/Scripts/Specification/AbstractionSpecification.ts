import { AndSpecification } from "./AndSpecification";
import { ISpecification } from "./ISpecification";

export abstract class AbstractSpecification<T> implements ISpecification<T> {
    abstract isSatisfiedBy(item: T): boolean;

    and(other: ISpecification<T>): ISpecification<T> {
        return new AndSpecification(this, other);
    }

    or(other: ISpecification<T>): ISpecification<T> {
        throw new Error("Method not implemented.");
    }

    not(other: ISpecification<T>): ISpecification<T> {
        throw new Error("Method not implemented.");
    }
}