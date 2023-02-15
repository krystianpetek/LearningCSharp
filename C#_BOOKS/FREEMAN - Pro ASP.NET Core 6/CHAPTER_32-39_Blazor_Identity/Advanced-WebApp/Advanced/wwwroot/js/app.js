function TSButton() {
    document.getElementById("ts-example").innerHTML = greeter(user);
}
class Student {
    firstName;
    middleInitial;
    lastName;
    fullName;
    constructor(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.middleInitial = middleInitial;
    }
}
function greeter(person) {
    return `Hello ${person.firstName} ${person.lastName}`;
}
let user = new Student("Fred", "M", "Smith");
//# sourceMappingURL=app.js.map