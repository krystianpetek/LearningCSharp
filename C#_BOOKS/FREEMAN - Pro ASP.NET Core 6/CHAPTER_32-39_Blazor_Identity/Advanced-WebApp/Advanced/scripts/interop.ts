function addTableRows(colCount: number): void {
    window.setTimeout(() => {
        let element: HTMLTableSectionElement = document.querySelector('tbody');
        let row: HTMLTableRowElement = document.createElement('tr');

        for (let i: number = 0; i < colCount; i++) {
            let cell: HTMLTableCellElement = document.createElement('td');
            cell.innerText = "New elements";
            row.appendChild(cell);
        }
        element.appendChild(row);
    }, 1000);
}