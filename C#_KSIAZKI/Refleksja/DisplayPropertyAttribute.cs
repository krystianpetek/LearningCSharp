using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refleksja
{
    [AttributeUsage(AttributeTargets.Property /*,AllowMultiple = true*/ )]
    internal class DisplayPropertyAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public DisplayPropertyAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
