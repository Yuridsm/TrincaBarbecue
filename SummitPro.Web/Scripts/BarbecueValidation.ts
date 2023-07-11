import BeginDateTimeInputValidation from "./Validation/BeginDateTimeInputValidation";
import DescriptionInputValidation from "./Validation/DescriptionInputValidation";
import EndDateTimeInputValidation from "./Validation/EndDateTimeInputValidation";

document.addEventListener('DOMContentLoaded', () => {
    const description = document.getElementById('description') as HTMLInputElement;
    const beginDateTime = document.getElementById('begin-datetime') as HTMLInputElement;
    const endDateTime = document.getElementById('end-datetime') as HTMLInputElement;

    const descriptionInputErrorMessage = document.getElementById('description-error-message') as HTMLInputElement;
    const beginDateTimeErrorMessage = document.getElementById('begin-datetime-error-message') as HTMLSpanElement;
    const endDateTimeErrorMessage = document.getElementById('end-datetime-error-message') as HTMLSpanElement;

    DescriptionInputValidation.execute(description, descriptionInputErrorMessage);
    BeginDateTimeInputValidation.execute(beginDateTime, endDateTime, beginDateTimeErrorMessage, endDateTimeErrorMessage);
    EndDateTimeInputValidation.execute(beginDateTime, endDateTime, beginDateTimeErrorMessage, endDateTimeErrorMessage);
});
