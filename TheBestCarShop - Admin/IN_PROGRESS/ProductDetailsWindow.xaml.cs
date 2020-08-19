using System;
using System.Collections.Generic;
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

namespace TheBestCarShop___Admin.IN_PROGRESS
{
    /// <summary>
    /// Interaction logic for ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();
        private Product DisplayedProduct = new Product();
        
        public ProductDetailsWindow(int productID)
        {
            InitializeComponent();
            
            try
            {
                DisplayedProduct = databaseHandler.GetProduct(productID);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            
            SetContexts();
        }

        private void SetContexts()
        {
            nameGrid.DataContext = DisplayedProduct;
            carDetailsGrid.DataContext = DisplayedProduct;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
