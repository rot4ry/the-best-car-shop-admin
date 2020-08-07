using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Commands;
using TheBestCarShop___Admin.Class_files.Views;

namespace TheBestCarShop___Admin.Class_files.Viewmodels
{
    public class AddProductViewModel
    {
        public NewProductView ProductModel { get; set; }
        public ICommand ProductViewCommand { get; set; }

        public AddProductViewModel()
        {
            ProductModel = new NewProductView();
            ProductViewCommand = new ProductViewCommand();
        }
    }
}
