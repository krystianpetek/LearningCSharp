using System.ComponentModel;

namespace Rozdzial18_2
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Person(string name)
        {
            Name = name;
        }
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }
    }
}