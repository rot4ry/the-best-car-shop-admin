using FluentValidation.Results;
using System;
using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Validators;
using TheBestCarShop___Admin.Class_files.Views;

namespace TheBestCarShop___Admin.Class_files.Commands
{
    public class AddNewAdminCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private NewAdminValidator _VALIDATOR = new NewAdminValidator();

        public bool CanExecute(object parameter)
        {
            NewAdminView newAdminView = parameter as NewAdminView;
            if(newAdminView is null)
            {
                return false;
            }
            
            ValidationResult output = _VALIDATOR.Validate(newAdminView);
            newAdminView.Errors = string.Join("\n", output.Errors);
            return output.IsValid;
        }

        public void Execute(object parameter) { }
    }
}
