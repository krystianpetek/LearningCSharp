using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refleksja
{
    internal class Person
    {
        [DisplayProperty("First name")]
        public string FirstName { get; set; }
        [DisplayProperty("Last name")]
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}
