(() => {
    'use strict';
    console.log("Boostrapping validation...");
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms: NodeListOf<HTMLFormElement> = document.querySelectorAll('.needs-validation');
  
    // Convert the NodeList to an array
    const formArray: HTMLFormElement[] = Array.prototype.slice.call(forms);
  
    // Loop over the array of forms and prevent submission
    formArray.forEach((form: HTMLFormElement) => {
      form.addEventListener('submit', (event: Event) => {
        if (!form.checkValidity()) {
          event.preventDefault();
          event.stopPropagation();
        }
  
        form.classList.add('was-validated');
      }, false);
    });
})();
