using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Class_files.Viewmodels;

namespace TheBestCarShop___Admin
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();
        private List<Product> _ProductList_BASIC_SRC = new List<Product>();
        private List<ProductInListViewmodel> Products_SRC = new List<ProductInListViewmodel>();
        //private ObservableCollection<ProductInListViewmodel> ProductsCollection = new ObservableCollection<ProductInListViewmodel>(); BETTER, not working at all though
        
        private List<string> SearchConditionsList = new List<string>
        {
           "None", "ID", "Brand", "Model", "Part name", "Part category", "Part manufacturer"
        };
        
        public ProductListWindow()
        {
            InitializeComponent();
            
            _ProductList_BASIC_SRC = databaseHandler.GetProductList();
            conditionsCB.ItemsSource = SearchConditionsList;

            ManageSearchData();  
        }
            

        private void ManageSearchData()
        {
            Products_SRC.Clear();
            
            foreach(Product product in _ProductList_BASIC_SRC)
            {
                ProductInListViewmodel prodModel = new ProductInListViewmodel();
                prodModel.Product = product;
                
                Products_SRC.Add(prodModel);
            }

            searchResultsList.ItemsSource = Products_SRC;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchCondition = conditionStringTB.Text;

            switch (conditionsCB.SelectedIndex)
            {
                case 0: //None
                    searchResultsList.ItemsSource = Products_SRC;
                    break;

                case 1: //ID
                    int id;
                    Int32.TryParse(searchCondition, out id);

                    if (id != 0)
                    {                    
                        if (Products_SRC.Where(x => x.Product.ProductID == id).ToList().Count() != 0)
                        {
                            searchResultsList.ItemsSource = Products_SRC
                                 .Where(x => x.Product.ProductID == id)
                                 .ToList();
                        }
                        else
                        {
                            int maxid = Products_SRC.Select(x => x.Product.ProductID).Max();
                            MessageBox.Show($"Maximum ID found in the database is: {maxid}", "You exceeded the maximum ID value.", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong.", "Check whether the requested ID is a number.", MessageBoxButton.OK);
                    }
                    break;

                case 2: //Brand
                    searchResultsList.ItemsSource = Products_SRC
                        .Where(x => x.Product.CarBrand.ToLower().Contains(searchCondition.ToLower()))
                        .ToList();
                    break;
                    
                case 3: //Model
                    searchResultsList.ItemsSource = Products_SRC
                        .Where(x => x.Product.CarModel.ToLower().Contains(searchCondition.ToLower()))
                        .ToList();
                    break;

                case 4: //Part name
                    searchResultsList.ItemsSource = Products_SRC
                        .Where(x => x.Product.Name.ToLower().Contains(searchCondition.ToLower()))
                        .ToList();
                    break;

                case 5: //Part category
                    searchResultsList.ItemsSource = Products_SRC
                        .Where(x => x.Product.Category.ToLower().Contains(searchCondition.ToLower()))
                        .ToList();
                    break;

                case 6: //Part manufacturer
                    searchResultsList.ItemsSource = Products_SRC
                        .Where(x => x.Product.Manufacturer.ToLower().Contains(searchCondition.ToLower()))
                        .ToList();
                    break;
            }
        }

        private void conditionsCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(conditionsCB.SelectedItem.ToString() == "None")
            {
                conditionStringTB.IsEnabled = false;
            }
            else
            {
                conditionStringTB.IsEnabled = true;
            }

            conditionStringTB.Text = "";
        }
    }
}
