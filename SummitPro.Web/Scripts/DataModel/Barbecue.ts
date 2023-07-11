import BeginDateGreaterThanEndDateSpecification from "../Specification/BeginDateGreaterThanEndDateSpecification";
import BeginDateTimeIsNotNullSpecification from "../Specification/BeginDateTimeNotNullSpecification";
import DescriptionIsNotNullSpecification from "../Specification/DescriptionIsNotNullSpecification";
import EndDateTimeIsNotNullSpecification from "../Specification/EndDateTimeIsNotNullSpecification";

export default class Barbecue {
    constructor(readonly description: string, readonly beginDateTime: Date, readonly endDateTime: Date, readonly additionalRemarks: string) {
    }

    public static validate(barbecue: Barbecue): boolean {
        const descriptionSpecification = new DescriptionIsNotNullSpecification();
        const beginDateTimeSpecification = new BeginDateTimeIsNotNullSpecification();
        const endDateTimeSpecification = new EndDateTimeIsNotNullSpecification();
        const endDateTimeInvariantSpeficiation = new BeginDateGreaterThanEndDateSpecification();

        return descriptionSpecification
            .and(beginDateTimeSpecification)
            .and(endDateTimeSpecification)
            .and(endDateTimeInvariantSpeficiation)
            .isSatisfiedBy(barbecue);
    }
}