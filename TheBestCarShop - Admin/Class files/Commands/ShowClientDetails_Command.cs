using System;
using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.IN_PROGRESS;

namespace TheBestCarShop___Admin.Class_files.Commands
{
    public class ShowClientDetails_Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (!(parameter is null))
            {
                return true;
            }
            else
                return false;
        }

        public void Execute(object parameter)
        {
            Client requestedClient = parameter as Client;
            ClientDetailsWindow cdw = new ClientDetailsWindow(requestedClient);
            cdw.ShowDialog();
        }
    }
}
