import Barbecue from "./DataModel/Barbecue";
import BeginDateGreaterThanEndDateSpecification from "./Specification/BeginDateGreaterThanEndDateSpecification";
import FieldIsNotNullSpecification from "./Specification/FieldIsNotNullSpecification";

document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('create-barbecue-identifier') as HTMLFormElement;

    form.addEventListener('submit', (event) => {
        event.preventDefault();

        const description = document.getElementById('description') as HTMLInputElement;
        const beginDateTime = document.getElementById('begin-datetime') as HTMLInputElement;
        const endDateTime = document.getElementById('end-datetime') as HTMLInputElement;
        const remarks = document.getElementById('additional-remarks') as HTMLTextAreaElement;

        const fieldIsNotNullSpecification = new FieldIsNotNullSpecification();
        const endDateTimeInvariantSpecification = new BeginDateGreaterThanEndDateSpecification();

        const barbecue = new Barbecue(
            description.value,
            new Date(beginDateTime.value),
            new Date(endDateTime.value),
            remarks.value
        );

        if (!fieldIsNotNullSpecification.isSatisfiedBy(description.value)) {
            const validationMessage = 'Description is required here.';

            description.setCustomValidity(validationMessage);
        }
        else if (!endDateTimeInvariantSpecification.isSatisfiedBy(barbecue)) {
            const validationMessage = 'End Datetime should greather than Begin Datetime';

            endDateTime.setCustomValidity(validationMessage);
        }
        else {
            beginDateTime.setCustomValidity('');
        }
    });
});


