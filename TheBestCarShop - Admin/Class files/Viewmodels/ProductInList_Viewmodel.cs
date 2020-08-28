using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Class_files.Commands;

namespace TheBestCarShop___Admin.Class_files.Viewmodels
{
    public class ProductInList_Viewmodel
    {
        public Product Product { get; set; }
        public ICommand Command { get; set; }

        public ProductInList_Viewmodel()
        {
            Product = new Product();
            Command = new ShowProductDetails_Command();
        } 
    }
}
