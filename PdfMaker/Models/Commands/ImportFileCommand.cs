using System;
using System.Windows.Input;

namespace PdfMaker.Models.Commands
{
    class ImportFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;

        public ImportFileCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
