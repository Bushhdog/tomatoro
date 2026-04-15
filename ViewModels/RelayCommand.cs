using System.Windows.Input;

namespace Tomatoro.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action _action;
        public bool CanExecute(object? parameter)
        {

            return true;

        }
        public void Execute(object? parameter)
        {
            _action();
        }
        public event EventHandler? CanExecuteChanged;
        

        public RelayCommand(Action execute) //Construtor
        {
            _action = execute;
        }
    }

    
}