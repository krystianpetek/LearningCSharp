using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozdzial6_9
{
    public partial class Person
    {
        #region Definicje metod umożliwiające rozbudowanie klasy
        partial void OnLastNameChanging(string value);
        partial void OnFirstNameChanging(string value);
        #endregion
        // …
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if ((_LastName != value))
                {
                    OnLastNameChanging(value);
                    _LastName = value;
                }
            }
        }
        private string _LastName;
        // …
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if ((_FirstName != value))
                {
                    OnFirstNameChanging(value);
                    _FirstName = value;
                }
            }
        }
        private string _FirstName;
    }
}
