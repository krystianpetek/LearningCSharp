using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVM_2_WFAiIS.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null) return true;

            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    
        public RelayCommand(Action<object> action, Func<object,bool> func)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            _execute = action;
            _canExecute = func;
        }
    }
}
