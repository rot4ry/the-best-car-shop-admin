using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheBestCarShop___Admin.Class_files.Commands
{
    public class ShowClientDetailsCommand : ICommand
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
            int clientID = (int)parameter;
            Console.WriteLine(clientID);
            //open client details window here using the id
        }
    }
}
