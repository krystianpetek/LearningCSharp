const username: string = "joe";
const password: string = "Secret123$";

window.addEventListener("DOMContentLoaded", () => {
  const controlDiv: HTMLElement = document.getElementById("controls");
  createButton(controlDiv, "Get Data", getData);
  createButton(controlDiv, "Log In", login);
  createButton(controlDiv, "Log Out", logout);
});

async function login() {
  const response: Response = await fetch("/api/account/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({
      username: username,
      password: password,
    }),
  });
  if (response.ok) {
    displayData("Logged in");
  } else {
    displayData(`Error: ${response.status}: ${response.statusText}`);
  }
}

async function logout() {
  const response: Response = await fetch("/api/account/logout", {
    method: "POST",
  });
  if (response.ok) {
    displayData("Logged out");
  } else {
    displayData(`Error: ${response.status}: ${response.statusText}`);
  }
}

function createButton(
  parent: HTMLElement,
  label: string,
  handler: () => Promise<void> | void
) {
  const button: HTMLButtonElement = document.createElement("button");
  button.classList.add("btn", "btn-primary", "m-2");
  button.innerText = label;
  button.onclick = handler;
  parent.appendChild(button);
}

async function getData() {
  let response: Response = await fetch("/api/people");
  if (response.ok) {
    let jsonData = await response.json();
    displayData(
      ...jsonData.map((item: ApiPeople) => `${item.surname}, ${item.firstname}`)
    );
  } else {
    displayData(`Error: ${response.status}: ${response.statusText}`);
  }
}

function displayData(...items: Array<string>) {
  const dataDiv: HTMLElement = document.getElementById("data");
  dataDiv.innerHTML = "";
  items.forEach((item: string) => {
    const itemDiv: HTMLDivElement = document.createElement("div");
    itemDiv.innerText = item;
    itemDiv.style.wordBreak = "break-word";
    dataDiv.appendChild(itemDiv);
  });
}

interface ApiPeople {
  surname: string;
  firstname: string;
}
