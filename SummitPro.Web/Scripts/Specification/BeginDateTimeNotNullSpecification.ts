import Barbecue from "../DataModel/Barbecue";
import { AbstractSpecification } from "./AbstractionSpecification";

export default class BeginDateTimeIsNotNullSpecification extends AbstractSpecification<Barbecue> {

    isSatisfiedBy(item: Barbecue): boolean {
        return item.beginDateTime != null;
    }
}