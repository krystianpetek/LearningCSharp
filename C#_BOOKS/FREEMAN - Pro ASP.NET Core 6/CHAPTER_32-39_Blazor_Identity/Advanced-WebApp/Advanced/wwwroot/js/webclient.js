const username = "joe";
const password = "Secret123$";
window.addEventListener("DOMContentLoaded", () => {
    const controlDiv = document.getElementById("controls");
    createButton(controlDiv, "Get Data", getData);
    createButton(controlDiv, "Log In", login);
    createButton(controlDiv, "Log Out", logout);
});
async function login() {
    const response = await fetch("/api/account/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            username: username,
            password: password,
        }),
    });
    if (response.ok) {
        displayData("Logged in");
    }
    else {
        displayData(`Error: ${response.status}: ${response.statusText}`);
    }
}
async function logout() {
    const response = await fetch("/api/account/logout", {
        method: "POST",
    });
    if (response.ok) {
        displayData("Logged out");
    }
    else {
        displayData(`Error: ${response.status}: ${response.statusText}`);
    }
}
function createButton(parent, label, handler) {
    const button = document.createElement("button");
    button.classList.add("btn", "btn-primary", "m-2");
    button.innerText = label;
    button.onclick = handler;
    parent.appendChild(button);
}
async function getData() {
    let response = await fetch("/api/people");
    if (response.ok) {
        let jsonData = await response.json();
        displayData(...jsonData.map((item) => `${item.surname}, ${item.firstname}`));
    }
    else {
        displayData(`Error: ${response.status}: ${response.statusText}`);
    }
}
function displayData(...items) {
    const dataDiv = document.getElementById("data");
    dataDiv.innerHTML = "";
    items.forEach((item) => {
        const itemDiv = document.createElement("div");
        itemDiv.innerText = item;
        itemDiv.style.wordBreak = "break-word";
        dataDiv.appendChild(itemDiv);
    });
}
//# sourceMappingURL=webclient.js.map