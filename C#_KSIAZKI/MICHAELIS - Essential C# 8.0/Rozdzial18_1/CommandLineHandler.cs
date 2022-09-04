﻿// CHAPTER 18: Reflection, Attributes, and Dynamic Programming

using System.Diagnostics;
using System.Reflection;

namespace Rozdzial18_1
{
    public class CommandLineHandler
    {
        public static void Parse(string[] args, object commandLine)
        {
            if (!TryParse(args, commandLine, out string? errorMessage))
                throw new InvalidOperationException(errorMessage);
        }
        public static bool TryParse(string[] args, object commandLine, out string? errorMessage)
        {
            bool success = false;
            errorMessage = null;

            foreach (string arg in args)
            {
                string option;
                if (arg[0] == '/' || arg[0] == '-')
                {
                    string[] optionParts = arg.Split(new char[] { ':' }, 2);

                    option = optionParts[0].Remove(0, 1);
                    PropertyInfo? property = commandLine.GetType().GetProperty(option,
                        BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (property != null)
                    {
                        if (property.PropertyType == typeof(bool))
                        {
                            property.SetValue(commandLine, true, null);
                            success = true;
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(commandLine, optionParts[1], null);
                            success = true;
                        }
                        else if (property.PropertyType == typeof(ProcessPriorityClass))
                        {
                            try
                            {
                                property.SetValue(commandLine, Enum.Parse(typeof(ProcessPriorityClass), optionParts[1], true), null);
                                success = true;
                            }
                            catch (ArgumentException e)
                            {
                                success = false;
                                errorMessage = $@"The option '{optionParts[1]}' is valid for '{option}'";
                            }
                        }
                        else
                        {
                            success = false;
                            errorMessage = $@"Data type '{property.PropertyType}' on '{commandLine.GetType()} is not supported.'";

                        }
                    }
                    else
                    {
                        success = false;
                        errorMessage = $@"Option '{option}' is not supported.";
                    }
                }
            }
            return success;
        }
    }
}
