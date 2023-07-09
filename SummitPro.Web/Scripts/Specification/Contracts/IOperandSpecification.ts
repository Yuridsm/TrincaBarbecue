import ISpecification from "./ISpecification";

export default interface IOperandSpecification<T> extends ISpecification<T> {
    and (other: ISpecification<T>): IOperandSpecification<T>;
}