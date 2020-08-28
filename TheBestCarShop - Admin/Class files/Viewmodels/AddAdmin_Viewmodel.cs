using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Commands;
using TheBestCarShop___Admin.Class_files.Views;

namespace TheBestCarShop___Admin.Class_files.Viewmodels
{
    public class AddAdmin_Viewmodel
    {
        public NewAdmin_View AdminModel { get; set; }
        public ICommand AdminValidationCommand { get; set; }

        public AddAdmin_Viewmodel()
        {
            AdminModel = new NewAdmin_View();
            AdminValidationCommand = new AddNewAdmin_Command();
        }
    }
}
