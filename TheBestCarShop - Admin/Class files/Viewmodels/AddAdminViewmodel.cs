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
    public class AddAdminViewmodel
    {
        public NewAdminView AdminModel { get; set; }
        public ICommand AdminValidationCommand { get; set; }

        public AddAdminViewmodel()
        {
            AdminModel = new NewAdminView();
            AdminValidationCommand = new AddNewAdminCommand();
        }
    }
}
