using FluentValidation.Results;
using System;
using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Validators;
using TheBestCarShop___Admin.Class_files.Views;

namespace TheBestCarShop___Admin.Class_files.Commands
{
    public class ProductViewCommand : ICommand
    {
        private NewProductValidator _PRODUCTVALIDATOR = new NewProductValidator();

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            NewProductView productView = parameter as NewProductView;
            if (productView is null)
            {
                return false;
            }

            ValidationResult output = _PRODUCTVALIDATOR.Validate(productView);
            productView.Errors = string.Join("\n", output.Errors);
            return output.IsValid;
        }

        public void Execute(object parameter) { }
    }
}

