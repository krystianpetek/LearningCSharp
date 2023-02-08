function TSButton() {
    document.getElementById("ts-example").innerHTML = greeter(user);
}
var Student = /** @class */ (function () {
    function Student(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.middleInitial = middleInitial;
    }
    return Student;
}());
function greeter(person) {
    return "Hello ".concat(person.firstName, " ").concat(person.lastName);
}
var user = new Student("Fred", "M", "Smith");
//# sourceMappingURL=app.js.map