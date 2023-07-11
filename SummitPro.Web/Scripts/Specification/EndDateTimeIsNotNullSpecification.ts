import Barbecue from "../DataModel/Barbecue";
import { AbstractSpecification } from "./Contracts/AbstractionSpecification";

export default class EndDateTimeIsNotNullSpecification extends AbstractSpecification<Barbecue> {

    isSatisfiedBy(item: Barbecue): boolean {
        return item.endDateTime != null;
    }
}