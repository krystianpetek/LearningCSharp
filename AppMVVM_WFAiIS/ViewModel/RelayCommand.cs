using System;
using System.Windows.Input;

public class RelayCommand : ICommand
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

    private Action<object> execute;
    private Func<object, bool>? canExecute;
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        if (execute == null)
            throw new ArgumentNullException(nameof(execute));
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        if (canExecute == null) return true;
        else return canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        execute?.Invoke(parameter);
    }
}
