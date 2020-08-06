using System.Windows.Input;
using TheBestCarShop___Admin.Commands;

namespace TheBestCarShop___Admin.Viewmodels
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
