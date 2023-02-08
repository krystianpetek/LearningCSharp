window.addEventListener('DOMContentLoaded', () => {
    function setVisibility (visible) {
        document.getElementById('categoryGroup').hidden = !visible;
        const input = document.getElementById('categoryInput');
        if (visible) {
            input.removeAttribute('disabled');
        } else {
            input.setAttribute('disabled', 'disabled');
        }
    }
    setVisibility(false);
    document.querySelector('select[name="Product.CategoryId"]')
        .addEventListener('change', (event) => {
            const element = event.currentTarget;
            setVisibility(element.value === '-1');
        });
});
// # sourceMappingURL=categoryEditor.js.map
