function addTableRows(columnCount, referenceRow) {
    window.setTimeout(() => {
        //let element: HTMLTableSectionElement = document.querySelector('tbody');
        let newRow = document.createElement('tr');
        for (let i = 0; i < columnCount; i++) {
            let cell = document.createElement('td');
            cell.innerText = 'New elements';
            newRow.appendChild(cell);
        }
        referenceRow.parentNode.insertBefore(newRow, referenceRow);
    }, 1000);
}
function createToggleButton(toggleServiceRef) {
    let tsToggle = document.getElementById('tsToggle');
    if (!tsToggle) {
        let sibling = document.querySelector('button:last-of-type');
        let button = document.createElement('button');
        button.classList.add('btn', 'btn-secondary', 'btn-block');
        button.innerText = 'TS toggle';
        button.id = "tsToggle";
        let serviceButton = button.cloneNode(true);
        serviceButton.innerText = "TS service toggle";
        sibling.parentNode.insertBefore(button, sibling.nextSibling);
        sibling.parentNode.insertBefore(serviceButton, button.nextSibling);
        button.onclick = () => DotNet.invokeMethodAsync('Advanced', 'ToggleEnabled');
        serviceButton.onclick = () => toggleServiceRef.invokeMethodAsync('ToggleComponents');
    }
}
//# sourceMappingURL=interop.js.map