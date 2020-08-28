using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Class_files.Commands;

namespace TheBestCarShop___Admin.Class_files.Viewmodels
{
    public class ClientInListViewmodel
    {
        public Client Client { get; set; }
        public ICommand Command { get; set; }

        public ClientInListViewmodel()
        {
            Client = new Client();
            Command = new ShowClientDetailsCommand();
        }
    }
}
