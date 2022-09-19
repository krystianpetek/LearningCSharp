using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Refleksja
{
    // wypisywanie wlasciwości obiektów oraz wartości tych właściwości / atrybuty i ich implementacja oraz zmiana wartości przy pomocy refleksji
    internal class Program
    {
        static void Main()
        {

            Address address = new Address()
            {
                City = "Krakow",
                PostalCode = "31-556",
                Street = "Grodzka 5"
            };
            Person person = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                Address = address
            };

            Console.WriteLine("Person:");
            Display(person);

            Console.WriteLine("Insert person property to update");
            var propertyToUpdate = Console.ReadLine();

            Console.WriteLine("Insert value");
            var value = Console.ReadLine();

            SetValue(person, propertyToUpdate, value);

            Console.WriteLine("\nPerson:");
            Display(person);

            Console.WriteLine("\nAddress:");
            Display(address);
        }


        static void Display(object obj)
        {
            Type objType = obj.GetType();
            var properties = objType.GetProperties();

            foreach (var property in properties)
            {
                var propValue = property.GetValue(obj);
                var propType = propValue.GetType();

                if (propType.IsPrimitive || propType == typeof(string))
                {
                    var displayPropertyAttribute = property.GetCustomAttribute<DisplayPropertyAttribute>();
                    if (displayPropertyAttribute != null)
                    {
                        Console.WriteLine($"{displayPropertyAttribute.DisplayName}: {propValue}");
                    }
                    else
                    {
                        Console.WriteLine($"{property.Name}: {propValue}");
                    }
                }
            }

        }
            static void SetValue<T>(T obj, string propName, string value)
            {
                Type objType = typeof(T);

                var propertyToUpdate = objType.GetProperty(propName);

                if(propertyToUpdate != null)
                {
                    propertyToUpdate.SetValue(obj, value);
                }
            }
    }
}
