using System;
using System.Windows.Input;

namespace Northwind.Application
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged = delegate { };

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;


        public Command(Action<object> execute) : this(execute, null)
        {

        }
        public Command(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute == null) || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, new EventArgs());
        }
    }
}
