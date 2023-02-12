function addTableRows(columnCount: number, referenceRow: HTMLTableRowElement): void {
    window.setTimeout(() => {
        //let element: HTMLTableSectionElement = document.querySelector('tbody');

        let newRow: HTMLTableRowElement = document.createElement('tr');

        for (let i: number = 0; i < columnCount; i++) {
            let cell: HTMLTableCellElement = document.createElement('td');
            cell.innerText = 'New elements';
            newRow.appendChild(cell);
        }
        referenceRow.parentNode.insertBefore(newRow, referenceRow);
    }, 1000);
}

function createToggleButton(toggleServiceRef: DotNet.DotNetObject) {
    let tsToggle: HTMLButtonElement = document.getElementById('tsToggle') as HTMLButtonElement;
    if (!tsToggle) {
        let sibling: HTMLButtonElement = document.querySelector('button:last-of-type');
        let button: HTMLButtonElement = document.createElement('button');
        button.classList.add('btn', 'btn-secondary', 'btn-block');
        button.innerText = 'TS toggle';
        button.id = "tsToggle"

        let serviceButton: HTMLButtonElement = button.cloneNode(true) as HTMLButtonElement;
        serviceButton.innerText = "TS service toggle"

        sibling.parentNode.insertBefore(button, sibling.nextSibling);
        sibling.parentNode.insertBefore(serviceButton, button.nextSibling);

        button.onclick = () => DotNet.invokeMethodAsync('Advanced', 'ToggleEnabled');
        serviceButton.onclick = () => toggleServiceRef.invokeMethodAsync('ToggleComponents');
    }
}