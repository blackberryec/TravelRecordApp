using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RegisterNavigationCommand : ICommand
    {
        private MainVM ViewModel;
        
        public event EventHandler CanExecuteChanged;

        public RegisterNavigationCommand(MainVM viewModel)
        {
            this.ViewModel = viewModel;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Navigate();        
        }
    }
}
