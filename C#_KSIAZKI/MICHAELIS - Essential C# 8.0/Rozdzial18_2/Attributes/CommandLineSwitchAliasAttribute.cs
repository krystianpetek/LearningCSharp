using System.Reflection;

namespace Rozdzial18_2.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class CommandLineSwitchAliasAttribute : Attribute
    {
        string Alias { get; }
        public CommandLineSwitchAliasAttribute(string alias)
        {
            Alias = alias;
        }
        public static void Attribute()
        {
            PropertyInfo property = typeof(CommandLineInfo).GetProperty("Help");
            CommandLineSwitchAliasAttribute attribute = property.GetCustomAttribute(typeof(CommandLineSwitchAliasAttribute), false) as CommandLineSwitchAliasAttribute;

            if (attribute?.Alias == "?")
            {
                Console.WriteLine("Help(?)");
            }
        }

        public static Dictionary<string, PropertyInfo> GetSwitches(object commandLine)
        {
            PropertyInfo[] properties;
            Dictionary<string, PropertyInfo> options = new Dictionary<string, PropertyInfo>();
            properties = commandLine.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                options.Add(property.Name, property);
                foreach (CommandLineSwitchAliasAttribute attribute in property.GetCustomAttributes(typeof(CommandLineSwitchAliasAttribute), false))
                {
                    options.Add(attribute.Alias.ToLower(), property);
                }
            }
            return options;
        }
    }
}