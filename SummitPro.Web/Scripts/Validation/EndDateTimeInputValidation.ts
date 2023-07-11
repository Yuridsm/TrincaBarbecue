export default class EndDateTimeInputValidation {

    public static execute(beginDateTime: HTMLInputElement, endDateTime: HTMLInputElement, beginDateTimeSpan: HTMLSpanElement, endDateTimeSpan: HTMLSpanElement): void {

        endDateTime.addEventListener('blur', (event: Event) => {

            const begin = new Date(beginDateTime.value);
            const end = new Date(endDateTime.value);

            if (begin >= end) {
                endDateTimeSpan.textContent = 'Este data deve ser maior que end datetime';
            } else {
                endDateTimeSpan.textContent = '';
                beginDateTimeSpan.textContent = '';
            }
        });
    }
}