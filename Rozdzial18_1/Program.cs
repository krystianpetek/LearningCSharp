// CHAPTER 18: Reflection, Attributes, and Dynamic Programming

namespace Rozdzial18_1
{
    public class Program
    {
        public static void Main()
        {
            Contact contact = new Contact("Krystian", "Petek");
            foreach (var item in contact)
            {
                Console.WriteLine(item);
            }

            var typeToAnalize = typeof(Contact);
            Console.WriteLine($"typeToAnalize.Name: " + typeToAnalize.Name);
            Console.WriteLine($"typeToAnalize.IsPublic: " + typeToAnalize.IsPublic);
            Console.WriteLine($"typeToAnalize.BaseType: " + typeToAnalize.BaseType);
            Console.WriteLine($"typeToAnalize.GetInterfaces(): ->");
            typeToAnalize.GetInterfaces().ToList().ForEach(x => Console.WriteLine($"\tInterfaceType: " + x));
            Console.WriteLine($"typeToAnalize.Assembly: " + typeToAnalize.Assembly);
            Console.WriteLine($"typeToAnalize.GetProperties(): ->");
            typeToAnalize.GetProperties().ToList().ForEach(x => Console.WriteLine($"\tPropertyInfo: " + x));
            Console.WriteLine($"typeToAnalize.GetMethods(): ->");
            typeToAnalize.GetMethods().ToList().ForEach(x => Console.WriteLine($"\tMethodInfo: " + x));
            Console.WriteLine($"typeToAnalize.GetFields(): ->");
            typeToAnalize.GetFields().ToList().ForEach(x => Console.WriteLine($"\tMethodInfo: " + x));

            //771
        }
    }
}
