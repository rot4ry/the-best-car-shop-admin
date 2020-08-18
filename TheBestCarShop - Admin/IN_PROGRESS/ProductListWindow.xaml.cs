using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheBestCarShop___Admin.Class_files.Basics;

namespace TheBestCarShop___Admin
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();
        private List<Product> _ProductList_SRC = new List<Product>();

        private List<string> SearchConditionsList = new List<string>
        {
           "Brand", "Model", "Part name", "Part category", "Part manufacturer"
        };
        
        public ProductListWindow()
        {
            InitializeComponent();
            _ProductList_SRC = databaseHandler.GetProductList();
        }



        //binding a list
        //managing of the data grid
        //search engine, maybe based on one combo box (category of condition: name, brand, model, maybe not year and price..)
        //combobox -> textbox for a name -> search button
        //

    }
}
