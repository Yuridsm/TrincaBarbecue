export default class BeginDateTimeInputValidation {

    public static execute(beginDateTime: HTMLInputElement, endDateTime: HTMLInputElement, beginDateTimeSpan: HTMLSpanElement, endDateTimeSpan: HTMLSpanElement): void {
        
        beginDateTime.addEventListener('blur', (event: Event) => {

            const begin = new Date(beginDateTime.value);
            const end = new Date(endDateTime.value);

            if (begin >= end) {
                beginDateTimeSpan.textContent = 'Este data deve ser menor que end datetime';
            } else {
                beginDateTimeSpan.textContent = '';
                endDateTimeSpan.textContent = '';
            }
        });
    }
}
