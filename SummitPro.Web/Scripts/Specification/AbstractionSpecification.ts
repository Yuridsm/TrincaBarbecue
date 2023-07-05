import { ISpecification } from "./ISpecification";

export abstract class AbstractSpecification<T> implements ISpecification<T> {
    abstract isSatisfiedBy(item: T): boolean;

    isSatisfiedBy(element: T): boolean {
        throw new Error("Method not implemented.");
    }

    and(other: ISpecification<T>): ISpecification<T> {
        throw new Error("Method not implemented.");
    }

    or(other: ISpecification<T>): ISpecification<T> {
        throw new Error("Method not implemented.");
    }

    not(other: ISpecification<T>): ISpecification<T> {
        throw new Error("Method not implemented.");
    }
}