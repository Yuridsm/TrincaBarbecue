import Barbecue from "../DataModel/Barbecue";
import { AbstractSpecification } from "./Contracts/AbstractionSpecification";

export default class BeginDateGreaterThanEndDateSpecification extends AbstractSpecification<Barbecue> {
    isSatisfiedBy(item: Barbecue): boolean {
        return item.beginDateTime < item.endDateTime;
    }
}
