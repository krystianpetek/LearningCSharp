using System;
using System.Windows.Input;

namespace AppMVVM_3_WFAiIS.ViewModel
{
    internal class RelayCommand : ICommand
    {
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

        public RelayCommand(Action<object> actionExecute, Func<object, bool> funcCanExecute)
        {
            if (actionExecute == null)
                throw new ArgumentNullException(nameof(actionExecute));
            _execute = actionExecute;
            _canExecute = funcCanExecute;
        }

        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public bool CanExecute(object? parameter)
        {
            if (parameter == null) return true;
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
