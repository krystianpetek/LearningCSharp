namespace Rozdzial06_9
{
    internal partial class Person
    {
        private partial void OnLastNameChanging(string value);

        private partial void OnFirstNameChanging(string value);

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