namespace Rozdzial15_3
{
    public class Department
    {
        public long Id { get; }
        public string Name { get; }

        public Department(string name, long id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}