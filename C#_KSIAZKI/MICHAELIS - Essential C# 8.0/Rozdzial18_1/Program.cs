// CHAPTER 18: Reflection, Attributes, and Dynamic Programming

using System.Diagnostics;
using System.Reflection;

namespace Rozdzial18_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region My Example via Contact class
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
            #endregion

            #region Using Type.GetProperties() to obtain an Object's Public Properties for DateTime instance
            DateTime dateTime = new DateTime();
            Type type = dateTime.GetType();

            foreach (PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }
            #endregion

            #region Using typeof() to create System.Type instance
            ThreadPriorityLevel priority;
            priority = (ThreadPriorityLevel)Enum.Parse(typeof(ThreadPriorityLevel), "Idle");
            #endregion

            #region Dynamically Invoking a member
            CommandLineInfo commandLine = new CommandLineInfo();
            if (!CommandLineHandler.TryParse(args, commandLine, out string? errorMessage))
            {
                Console.WriteLine(errorMessage);
                DisplayHelp();
            }
            if (commandLine.Help)
            {
                DisplayHelp();
            }
            else
            {
                if (commandLine.Priority != ProcessPriorityClass.Normal)
                {
                    ;
                }
            }
            #endregion

        }

        #region CommandLineInfo
        private class CommandLineInfo
        {
            public bool Help { get; set; }
            public string? Out { get; set; }
            public ProcessPriorityClass Priority { get; set; } = ProcessPriorityClass.Normal;
        }
        #endregion

        #region DisplayHelp
        private static void DisplayHelp()
        {
            Console.WriteLine("Compress.exe /Out:<filename> /Help \n" +
                "/Priority:RealTime|High|" +
                "AboveNormal|Normal|BelowNormal|Idle");
        }
        #endregion
    }
}
