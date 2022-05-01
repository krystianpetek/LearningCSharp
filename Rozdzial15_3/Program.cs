using Rozdzial15_3;

void Print<T>(IEnumerable<T> collection)
{
    foreach (T item in collection)
        Console.WriteLine("\t" + item);
}

Console.WriteLine("List of departments:");
IEnumerable<Department> departments = CorporateData.Departments;
Print(departments);

Console.WriteLine("\nList of employees:");
IEnumerable<Employee> employees = CorporateData.Employees;
Print(employees);

// inner join with Join()
Console.WriteLine("\nInner join using Join() method employees => departments");
IEnumerable<(int Id, string Name, string Title, Department department)> employeeWithOwnDepartments = employees.Join(departments, employee => employee.DepartmentId, department => department.Id, (emp, dep) => (emp.Id, emp.Name, emp.Title, dep));
foreach (var item in employeeWithOwnDepartments)
{
    Console.WriteLine($"\t{item.Name} ({item.Title})");
    Console.WriteLine($"\t\t{item.department}");
}
// another way of this join
Console.WriteLine("\nInner join using Join() method departments => employees");
IEnumerable<(long Id, string Name, Employee employee)> departmentsWithEmployeesWhoWorkInIt = departments.Join(
    employees, department => department.Id, employee => employee.DepartmentId, (dep, emp) => (dep.Id, dep.Name, emp));
foreach (var item in departmentsWithEmployeesWhoWorkInIt)
{
    Console.WriteLine($"\t{item.Name}");
    Console.WriteLine($"\t\t{item.employee}");
}

// GroupBy()
Console.WriteLine("\nGrouping records using GroupBy() method by Employees => departmentId");
IEnumerable<IGrouping<int, Employee>> groupedEmployees = employees.GroupBy(employee => employee.DepartmentId);
foreach (IGrouping<int, Employee> employeeGroup in groupedEmployees)
{
    Console.WriteLine();
    foreach (Employee employee in employeeGroup)
    {
        Console.WriteLine($"\t{employee}");
    }
    Console.WriteLine($"\tCount: {employeeGroup.Count()}");
}

// GroupJoin implementing OneToMany Relationship Departments and Employee who works in it
Console.WriteLine("\n Implementing OneToMany Relationship using GroupJoin() method by Employees => departmentId");
IEnumerable<(long id, string name, IEnumerable<Employee> employees)> groupedEmployeeByDepartmentsWhereWorks = departments.GroupJoin
    (employees,
    department => department.Id,
    employee => employee.DepartmentId,
    (dep, depEmp) => (dep.Id, dep.Name, depEmp));

foreach (var item in groupedEmployeeByDepartmentsWhereWorks)
{
    if (item.employees.Count() == 0)
        continue;
    Console.WriteLine($"\t{item.name}");
    foreach (var emp in item.employees)
    {
        Console.WriteLine($"\t\t{emp}");
    }
};

// GroupJoin and SelectMany to show Left Outer Join Departments whose don't have employee
Console.WriteLine("\nImplementing GroupJoin and SelectMany to select Left Outer Join Departments that doesn't have an employee");
var groupJoinAndSelectManyToLeftOuterJoinDepartments = departments.GroupJoin(
    employees,
    department => department.Id,
    employee => employee.DepartmentId,
    (department, departmentEmployee) => new
    {
        department.Id,
        department.Name,
        employees = departmentEmployee
    }).SelectMany(
    departmentRecord => departmentRecord.employees.DefaultIfEmpty(),
    (departmentRecord, employee) => new
    {
        departmentRecord.Id,
        departmentRecord.Name,
        departmentRecord.employees
    }).Distinct();

foreach (var item in groupJoinAndSelectManyToLeftOuterJoinDepartments)
{
    Console.WriteLine($"\t{item.Name}");
    foreach (var emp in item.employees)
    {
        Console.WriteLine($"\t\t{emp}");
    }
};