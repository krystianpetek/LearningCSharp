namespace Rozdzial15_3
{
    public static class CorporateData
    {
        public static readonly Department[] Departments = new Department[]
        {
            new Department("Corporate",0),
            new Department("Human Resources", 1),
            new Department("Engineering", 2),
            new Department("Information Technology", 3),
            new Department("Philanthropy", 4),
            new Department("Marketing",5)
        };

        public static readonly Employee[] Employees = new Employee[]
        {
            new Employee("Mark Michaelis", "Chief Computer Nerd", 0),
            new Employee("Michael Stokesbary", "Senior Computer Wizard", 2),
            new Employee("Brian Jones", "Enterprise Integration Guru", 2),
            new Employee("Anne Beard", "HR Director", 1),
            new Employee("Pat Dever", "Enterprise Architect", 3),
            new Employee("Kevin Bost", "Programmer Extraordinaire", 2),
            new Employee("Thomas Heavey", "Software Architect", 2),
            new Employee("Eric Edmonds", "Philanthropy Coordinator", 4)
        };
    }
}