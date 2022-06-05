using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private Func<object, bool> canExecute;
    private Action<object> execute;

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        if (execute == null) throw new ArgumentException("Parametr 'execute' nie może być pusty (null)");
        this.execute = execute;
        this.canExecute = canExecute; 
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter)
    {
        return (canExecute == null) ? true : canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }
}

