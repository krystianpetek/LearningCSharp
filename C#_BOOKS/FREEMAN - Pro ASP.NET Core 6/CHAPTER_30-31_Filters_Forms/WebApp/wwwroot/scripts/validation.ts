window.addEventListener('DOMContentLoaded', (e : Event) => {
    document.querySelectorAll('input.input-validation-error')
        .forEach((element) => {
            element.classList.add('is-invalid')
        })
})
