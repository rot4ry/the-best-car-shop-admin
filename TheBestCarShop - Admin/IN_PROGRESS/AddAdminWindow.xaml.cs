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
    /// Interaction logic for AddAdminWindow.xaml
    /// </summary>
    public partial class AddAdminWindow : Window
    {
        //FirstName, 
        //SecondName,
        //CompanyName,
        //Email,
        //Phone,
        //Country,
        //City,
        //Street,
        //Postcode,
        //BuildingNumber,
        //Username,
        //Password,
        private Client _ADMIN;

        public AddAdminWindow(Client admin)
        {
            InitializeComponent();
            _ADMIN = admin as Client;
            //confirm adding a new administrator with a username and a password
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
