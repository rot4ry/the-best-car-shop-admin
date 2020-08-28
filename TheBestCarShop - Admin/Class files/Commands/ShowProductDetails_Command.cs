using System;
using System.Windows.Input;
using TheBestCarShop___Admin.Windows;

namespace TheBestCarShop___Admin.Class_files.Commands
{
    public class ShowProductDetails_Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (!(parameter is null))
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            int ProductID = (int)parameter;
            ProductDetailsWindow pdw = new ProductDetailsWindow(ProductID);
            pdw.ShowDialog();
        }
    }
}
