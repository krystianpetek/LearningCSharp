function addTableRows(columnCount, referenceRow) {
    window.setTimeout(function () {
        //let element: HTMLTableSectionElement = document.querySelector('tbody');
        var newRow = document.createElement('tr');
        for (var i = 0; i < columnCount; i++) {
            var cell = document.createElement('td');
            cell.innerText = 'New elements';
            newRow.appendChild(cell);
        }
        referenceRow.parentNode.insertBefore(newRow, referenceRow);
    }, 1000);
}
function createToggleButton(toggleServiceRef) {
    var tsToggle = document.getElementById('tsToggle');
    if (!tsToggle) {
        var sibling = document.querySelector('button:last-of-type');
        var button = document.createElement('button');
        button.classList.add('btn', 'btn-secondary', 'btn-block');
        button.innerText = 'TS toggle';
        button.id = "tsToggle";
        var serviceButton = button.cloneNode(true);
        serviceButton.innerText = "TS service toggle";
        sibling.parentNode.insertBefore(button, sibling.nextSibling);
        sibling.parentNode.insertBefore(serviceButton, button.nextSibling);
        button.onclick = function () { return DotNet.invokeMethodAsync('Advanced', 'ToggleEnabled'); };
        serviceButton.onclick = function () { return toggleServiceRef.invokeMethodAsync('ToggleComponents'); };
    }
}
//# sourceMappingURL=interop.js.map