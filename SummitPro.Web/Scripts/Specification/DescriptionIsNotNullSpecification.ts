import Barbecue from "../DataModel/Barbecue";
import { AbstractSpecification } from "./Contracts/AbstractionSpecification";

export default class DescriptionIsNotNullSpecification extends AbstractSpecification<Barbecue> {

    isSatisfiedBy(item: Barbecue): boolean {
        return item.description != null || item.description != '';
    }
}