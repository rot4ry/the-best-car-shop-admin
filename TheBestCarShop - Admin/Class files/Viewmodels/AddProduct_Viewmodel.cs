using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Commands;
using TheBestCarShop___Admin.Class_files.Views;

namespace TheBestCarShop___Admin.Class_files.Viewmodels
{
    public class AddProduct_Viewmodel
    {
        public NewProduct_View ProductModel { get; set; }
        public ICommand ProductViewCommand { get; set; }

        public AddProduct_Viewmodel()
        {
            ProductModel = new NewProduct_View();
            ProductViewCommand = new ProductView_Command();
        }
    }
}
