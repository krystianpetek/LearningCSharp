using System.Xml.Linq;

namespace Rozdzial18_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Invoking reflection using dynamic
            dynamic data = "Hello!  My name is Inigo Montoya";
            Console.WriteLine(data);
            data = (double)data.Length;

            data = data * 3.5 + 28.6;
            if (data == 2.4 + 112 + 26.2)
            {
                Console.WriteLine($"{data} makes for a long triathlon.");
            }
            else
            {
                data.NonExistentMethodCallStillCompiles();
            }
            #endregion

            #region Binding to XML Element without dynamic
            XElement person = XElement.Parse(@"
<Person>
<FirstName>Inigo</FirstName>
<LastName>Montoya</LastName>
</Person>");
            Console.WriteLine($"{person.Descendants("FirstName").FirstOrDefault().Value}");
            Console.WriteLine($"{person.Descendants("LastName").FirstOrDefault().Value}");
            #endregion

            #region Biding to XML Elements using dynamic
            dynamic personDynamic = DynamicXml.Parse(@"
<Person>
<FirstName>Inigo</FirstName>
<LastName>Montoya</LastName>
</Person>");
            Console.WriteLine($"{personDynamic.FirstName} {personDynamic.LastName}");
            #endregion


        }
    }
}
