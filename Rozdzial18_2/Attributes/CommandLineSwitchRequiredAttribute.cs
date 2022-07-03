using System.Reflection;

namespace Rozdzial18_2.Attributes
{
    public class CommandLineSwitchRequiredAttribute : Attribute
    {
        public static string[] GetMissingRequiredOptions(object commandLine)
        {
            List<string> missingOptions = new List<string>();
            PropertyInfo[] propertiesInfo = commandLine.GetType().GetProperties();

            foreach (PropertyInfo property in propertiesInfo)
            {
                var attributes = property.GetCustomAttributes(typeof(CommandLineSwitchRequiredAttribute), false);

                if (attributes.Length > 0 && property.GetValue(commandLine, null) == null)
                {
                    missingOptions.Add(property.Name);
                }
            }
            return missingOptions.ToArray();
        }
    }
}
