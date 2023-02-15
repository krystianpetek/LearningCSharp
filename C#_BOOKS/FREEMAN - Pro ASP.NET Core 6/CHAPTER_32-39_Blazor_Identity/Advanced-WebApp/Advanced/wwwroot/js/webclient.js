const username = "joe";
const password = "Secret123$";
let token;
window.addEventListener("DOMContentLoaded", () => {
    const controlDiv = document.getElementById("controls");
    createButton(controlDiv, "Get Data", getData);
    createButton(controlDiv, "Log In", loginBearer);
    createButton(controlDiv, "Log Out", logoutBearer);
});
async function loginBearer() {
    const response = await fetch("/api/account/token", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            username: username,
            password: password,
        }),
    });
    if (response.ok) {
        const tokenInfo = await response.json();
        if (tokenInfo.success) {
            token = tokenInfo.token;
        }
        displayData("Logged in", token);
    }
    else {
        displayData(`Error: ${response.status}: ${response.statusText}`);
    }
}
async function logoutBearer() {
    token = "";
    displayData("Logged out");
}
async function loginCookie() {
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
async function logoutCookie() {
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
    let response = await fetch("/api/people", {
        headers: { Authorization: `Bearer ${token}` },
    });
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