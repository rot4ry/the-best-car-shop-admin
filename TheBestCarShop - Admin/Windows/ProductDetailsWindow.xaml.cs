using System;
using System.Windows;
using System.Windows.Controls;
using TheBestCarShop___Admin.Class_files.Basics;


namespace TheBestCarShop___Admin.Windows
{
    /// <summary>
    /// Interaction logic for ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();
        
        private Product DisplayedProduct = new Product();
        private ProductStatistic ProductStats = new ProductStatistic();
        
        public ProductDetailsWindow(int productID)
        {
            InitializeComponent();
            SetContexts(productID);
        }

        private void SetContexts(int productID)
        {
            try
            {
                DisplayedProduct = databaseHandler.GetProduct(productID);
                ProductStats = databaseHandler.GetProductSalesDetails(productID);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            nameGrid.DataContext = DisplayedProduct;
            carDetailsGrid.DataContext = DisplayedProduct;
            productDetailsGrid.DataContext = DisplayedProduct;

            if (!(ProductStats.AmountSold == 0))
            {
                statisticsGrid.IsEnabled = true;
                statisticsGrid.DataContext = ProductStats;
            }
            else
            { statisticsGrid.IsEnabled = false; }

            if (DisplayedProduct.Quantity == 0)
                updateAvailabilityButton.IsEnabled = false;

            else
                updateAvailabilityButton.IsEnabled = true;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void updateAvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            if(DisplayedProduct.IsAvailable == true)
                databaseHandler.UpdateProductField("IsAvailable", "false", DisplayedProduct.ProductID);
            else
                databaseHandler.UpdateProductField("IsAvailable", "true", DisplayedProduct.ProductID);

            try
            {
                SetContexts(DisplayedProduct.ProductID);
            }
            catch(Exception UpdateException) 
            {
                Console.WriteLine(UpdateException.Message);
            }
        }

        private void updateQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            databaseHandler.UpdateProductField("Quantity", quantityTB.Text, DisplayedProduct.ProductID);

            try
            {
                SetContexts(DisplayedProduct.ProductID);
            }
            catch (Exception UpdateException)
            {
                Console.WriteLine(UpdateException.Message);
            }
        }

        private void quantityTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            int quantity;
            if (Int32.TryParse(quantityTB.Text, out quantity))
            {
                if (quantity == 0)
                    updateQuantityButton.IsEnabled = false;
                if(quantity>0)
                    updateQuantityButton.IsEnabled = true;
            }
            else
                updateQuantityButton.IsEnabled = false;
        }
    }
}
