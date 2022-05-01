namespace Rozdzial15_3
{
    public class Employee
    {
        private static int id = 0;
        public int Id { get; }
        public string Name { get; }
        public string Title { get; }
        public int DepartmentId { get; }

        public Employee(string name, string title, int departmentId)
        {
            Id = ++id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            DepartmentId = departmentId;
        }

        public override string ToString()
        {
            return $"{Name} ({Title})";
        }
    }
}