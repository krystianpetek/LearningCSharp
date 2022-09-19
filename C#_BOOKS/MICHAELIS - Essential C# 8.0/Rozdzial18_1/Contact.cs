// CHAPTER 18: Reflection, Attributes, and Dynamic Programming

using System.Collections;

namespace Rozdzial18_1
{
    public class Contact : IEnumerable<string>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Lazy<Contact> ExampleField = new Lazy<Contact>(() => new Contact("Krystian", "Petek"));
        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public IEnumerator<string> GetEnumerator()
        {
            yield return this.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
