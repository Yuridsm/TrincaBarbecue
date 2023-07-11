export default class DescriptionInputValidation {
    
    public static execute(element: HTMLInputElement, span: HTMLSpanElement): void {
        element.addEventListener('blur', (event: Event) => {

            if (element.value === '' || element.value === null || element.value === undefined) {
                span.textContent = 'Esse campo deve ser preenchido';
            } else {
                span.textContent = '';
            }
        });
    }
}