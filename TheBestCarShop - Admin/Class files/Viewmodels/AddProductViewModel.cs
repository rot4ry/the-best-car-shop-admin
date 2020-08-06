using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheBestCarShop___Admin.Commands;
using FluentValidation;

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
