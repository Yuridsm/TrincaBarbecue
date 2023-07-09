import IOperandSpecification from "./IOperandSpecification";
import ISpecification from "./ISpecification";

export abstract class AbstractSpecification<T> implements IOperandSpecification<T> {
    abstract isSatisfiedBy(element: T): boolean;

    and(other: ISpecification<T>): IOperandSpecification<T> {
        throw new Error("Method not implemented.");
    }
}
