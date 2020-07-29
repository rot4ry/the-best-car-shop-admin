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

namespace TheBestCarShop___Admin.IN_PROGRESS
{
    /// <summary
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();
        

        public AddProductWindow()
        {
            InitializeComponent();
            
            brandCB.ItemsSource = databaseHandler.GetBrands();
            categoryCB.ItemsSource = databaseHandler.GetCategories();
            manufacturerCB.ItemsSource = databaseHandler.GetManufacturers();
            isAvailableCB.ItemsSource = new string[] {"", "yes", "no"};
        }

        private void SetContexts()
        {
            brandCB.DataContext = databaseHandler.GetBrands();
            //after a brand is chosen modelCB.DataContext = databaseHandler.GetModels();
            categoryCB.DataContext = databaseHandler.GetCategories();
            manufacturerCB.DataContext = databaseHandler.GetManufacturers();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            //database insert
        }
    }
}
