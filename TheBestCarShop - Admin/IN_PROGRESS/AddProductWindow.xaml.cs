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
        
        private List<string> _BrandSRC          = new List<string>() {""};
        private List<string> _ModelSRC          = new List<string>() {""};
        private List<string> _CategorySRC       = new List<string>() {""};
        private List<string> _ManufacturerSRC   = new List<string>() {""};
        private List<string> _AvailableSRC      = new List<string>(){ "Yes", "No" };
        
        public AddProductWindow()
        {
            InitializeComponent();
            SetSources();

            brandCB.ItemsSource         = _BrandSRC;
            categoryCB.ItemsSource      = _CategorySRC;
            manufacturerCB.ItemsSource  = _ManufacturerSRC;
            isAvailableCB.ItemsSource   = _AvailableSRC;
        }

        private void SetSources()
        {
            _BrandSRC.AddRange(databaseHandler.GetBrands());
            _CategorySRC.AddRange(databaseHandler.GetCategories());
            _ManufacturerSRC.AddRange(databaseHandler.GetManufacturers());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addProductButton_Click(object sender, RoutedEventArgs e)
        {
            //database insert
            AddProductWindow apw = new AddProductWindow();
            this.Close();
            apw.ShowDialog();
        }
        
        //Brand
        private void brandCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (brandCB.SelectedItem.ToString() != "")
            {
                modelCB.ItemsSource = databaseHandler.GetModelsByBrand(brandCB.SelectedItem.ToString()).Prepend("");
                newBrandTB.IsEnabled = false;
            }
            else
            {
                modelCB.ItemsSource = new List<string>(){""};
                newBrandTB.IsEnabled = true;
            }

        }
        private void newBrandTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(newBrandTB.Text != "")
            {
                brandCB.IsEnabled = false;
            }
            else
            {
                brandCB.IsEnabled = true;
            }
        }

        //Model
        private void modelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(modelCB.SelectedItem == null)
            {
                newModelTB.IsEnabled = true;
            }
            else
            {
                if (modelCB.SelectedItem.ToString() != "")
                {
                    newModelTB.IsEnabled = false;
                }
                else
                {
                    newModelTB.IsEnabled = true;
                }
            }
        }
        private void newModelTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(newModelTB.Text != "")
            {
                modelCB.IsEnabled = false;
            }
            else
            {
                modelCB.IsEnabled = true;
            }
        }

        //Category
        private void categoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(categoryCB.SelectedItem.ToString() != "")
            {
                newCategoryTB.IsEnabled = false;
            }
            else
            {
                newCategoryTB.IsEnabled = true;
            }
        }
        private void newCategoryTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(newCategoryTB.Text != "")
            {
                categoryCB.IsEnabled = false;
            }
            else
            {
                categoryCB.IsEnabled = true;
            }
        }

        //Manufacturer
        private void manufacturerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(manufacturerCB.SelectedItem.ToString() != "")
            {
                newManufacturerTB.IsEnabled = false;
            }
            else
            {
                newManufacturerTB.IsEnabled = true;
            }
        }
        private void newManufacturerTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(newManufacturerTB.Text != "")
            {
                manufacturerCB.IsEnabled = false;
            }
            else
            {
                manufacturerCB.IsEnabled = true;
            }
        }
    }
}
