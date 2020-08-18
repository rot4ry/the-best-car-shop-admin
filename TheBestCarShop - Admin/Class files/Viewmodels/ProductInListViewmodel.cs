using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Class_files.Commands;

namespace TheBestCarShop___Admin.Class_files.Viewmodels
{
    public class ProductInListViewmodel
    {
        public Product Product { get; set; }
        public ICommand Command { get; set; }

        public ProductInListViewmodel()
        {
            Product = new Product();
            Command = new ShowProductDetailsCommand();
        }
    }
}
