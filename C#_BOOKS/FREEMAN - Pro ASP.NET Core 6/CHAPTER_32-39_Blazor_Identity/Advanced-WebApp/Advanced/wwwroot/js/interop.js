function addTableRows(colCount) {
    window.setTimeout(function () {
        var element = document.querySelector('tbody');
        var row = document.createElement('tr');
        for (var i = 0; i < colCount; i++) {
            var cell = document.createElement('td');
            cell.innerText = "New elements";
            row.appendChild(cell);
        }
        element.appendChild(row);
    }, 1000);
}
//# sourceMappingURL=interop.js.map