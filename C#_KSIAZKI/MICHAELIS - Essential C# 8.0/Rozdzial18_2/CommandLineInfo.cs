using Rozdzial18_2.Attributes;
using System.ComponentModel;
using System.Diagnostics;

namespace Rozdzial18_2
{
    class CommandLineInfo
    {
        [CommandLineSwitchAlias("?")]
        public bool Help { get; set; }

        [CommandLineSwitchRequired]
        [CommandLineSwitchAlias("FileName")]
        public string? Out { get; set; }

        public ProcessPriorityClass Priority { get; set; } = ProcessPriorityClass.Normal;

        [return: Description("Returns true if the object is in a valid state.")]
        public bool IsValid()
        {
            // ...
            return true;
        }
    }
}