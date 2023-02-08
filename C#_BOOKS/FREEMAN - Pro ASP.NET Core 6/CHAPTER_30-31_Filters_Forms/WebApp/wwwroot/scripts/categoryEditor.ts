window.addEventListener('DOMContentLoaded', () => {
    function setVisibility (visible: boolean): void {
        document.getElementById('categoryGroup').hidden = !visible;
        const input: HTMLElement = document.getElementById('categoryInput')
        if (visible) {
            input.removeAttribute('disabled');
        } else {
            input.setAttribute('disabled', 'disabled');
        }
    }
    setVisibility(false);
    document.querySelector('select[name="Product.CategoryId"]')
        .addEventListener('change', (event: Event): void => {
            const element: HTMLInputElement = event.currentTarget as HTMLInputElement;
            setVisibility(element.value === '-1');
        })
});
