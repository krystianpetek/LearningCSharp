#define CONDITIONAL_A

using System.Diagnostics;

namespace Rozdzial18_2
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            #region Determining Whether a Class or Method Supports Generics
            Type type = typeof(Nullable<>);
            Console.WriteLine($"Nullable<>.ContainsGenericParameters: " + type.ContainsGenericParameters);
            Console.WriteLine($"Nullable<>.IsGenericType: " + type.IsGenericType);

            type = typeof(Nullable<DateTime>);

            Console.WriteLine($"Nullable<DateTime>.ContainsGenericParameters: " + type.ContainsGenericParameters);
            Console.WriteLine($"Nullable<DateTime>.IsGenericType: " + type.IsGenericType);
            #endregion

            #region Obtaining type parameters for generic class or method
            Stack<int> stack = new Stack<int>();
            Type t = stack.GetType();

            foreach (Type parameter in t.GetGenericArguments())
            {
                Console.WriteLine($"Type parameter: {parameter.FullName}");
            }
            #endregion

            #region Using FlagAttribute
            string fileName = @"enumtest.txt";
            FileInfo file = new FileInfo(fileName);
            if (File.Exists(nameof(file)))
            {
                file.Attributes = FileAttributes.Hidden | FileAttributes.ReadOnly;

                Console.WriteLine("\"{0}\" outputs as \"{1}\"", file.Attributes.ToString().Replace(",", " |"), file.Attributes);

                FileAttributes attributes = (FileAttributes)Enum.Parse(typeof(FileAttributes), file.Attributes.ToString());

                Console.WriteLine(attributes);
            }
            else
                Console.WriteLine("File not exists");
            #endregion

            #region Using ConditionalAttributes to eliminate a call method
            Console.WriteLine("Begin...");
            MethodA();
            MethodB();
            Console.WriteLine("End...");

            [Conditional("CONDITIONAL_A")]
            static void MethodA()
            {
                Console.WriteLine("MethodA() executing...");
            }

            [Conditional("CONDITIONAL_B")]
            static void MethodB()
            {
                Console.WriteLine("MethodB() executing...");
            }
            #endregion

            #region Using ObsoleteAttribute
            [Obsolete]
            static void ObsoleteMethod()
            { }

            ObsoleteMethod();
            #endregion
        }
    }
}