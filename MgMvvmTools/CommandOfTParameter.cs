using System;
using System.Windows.Input;

namespace MgMvvmTools
{
    public class Command<TParameter> : ICommand
    {
        private readonly Action<TParameter> _execute;
        private readonly Func<TParameter, bool> _canExecute;

        public Command(Action execute)
        {
            _execute = _ => execute();
        }

        public Command(Action<TParameter> execute)
        {
            _execute = execute;
        }

        public Command(Action execute, Func<bool> canExecute)
        {
            _execute = _ => execute();
            _canExecute = _ => canExecute();
        }

        public Command(Action<TParameter> execute, Func<TParameter, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute((TParameter) parameter);

        public void Execute(object parameter) => _execute((TParameter) parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}