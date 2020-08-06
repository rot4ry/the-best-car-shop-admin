using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using TheBestCarShop___Admin.IN_PROGRESS;
using TheBestCarShop___Admin.Validators;
using TheBestCarShop___Admin.Viewmodels;

namespace TheBestCarShop___Admin.Commands
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
            
            if(productView is null)
            {
                return false;
            }
            ValidationResult output = _PRODUCTVALIDATOR.Validate(productView);
            productView.Errors = string.Join("\n", output.Errors);
            return output.IsValid;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Success!", "Product has been added to the database.", MessageBoxButton.OK);
        }
    }
}
            
