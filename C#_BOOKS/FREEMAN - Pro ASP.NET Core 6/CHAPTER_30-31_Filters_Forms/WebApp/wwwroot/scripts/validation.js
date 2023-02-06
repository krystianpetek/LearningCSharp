window.addEventListener("DOMContentLoaded", (e) => {
    document.querySelectorAll("input.input-validation-error")
        .forEach((element) => {
            element.classList.add("is-invalid");
        });
});