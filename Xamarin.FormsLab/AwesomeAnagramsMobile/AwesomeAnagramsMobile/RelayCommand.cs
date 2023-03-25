using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AwesomeAnagramsMobile
{
    internal class RelayCommand : ICommand
    {
        private readonly Action action;
        public RelayCommand(Action action)
        {
            this.action = action;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
                action?.Invoke();
        }
    }
}
