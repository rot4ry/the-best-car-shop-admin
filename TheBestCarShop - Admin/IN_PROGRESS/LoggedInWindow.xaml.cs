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

namespace TheBestCarShop___Admin
{
    /// <summary>
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        private Client _ACCOUNTOWNER;
        public LoggedInWindow(Client _accountOwner)
        {
            InitializeComponent();
            _ACCOUNTOWNER = _accountOwner;
        }

        
        //PRODUCTS BUTTONS
        private void productsButton_Click(object sender, RoutedEventArgs e)
        {
            //show a list of products based on filters
        }

        private void newProductButton_Click(object sender, RoutedEventArgs e)
        {
            //add a new product
        }

        private void productStatsButton_Click(object sender, RoutedEventArgs e)
        {
            //show product statistics
        }

        
        //USERS BUTTONS
        private void viewAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            //show administrators list
        }

        private void viewUsersButton_Click(object sender, RoutedEventArgs e)
        {
            //show all normal users
        }

        private void newAdminButton_Click(object sender, RoutedEventArgs e)
        {
            //add a new administrator
        }

        private void clientStatsButton_Click(object sender, RoutedEventArgs e)
        {
            //show clients statistics
        }


        //OTHER BUTTONS
        private void accountButton_Click(object sender, RoutedEventArgs e)
        {
            //show account details
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            //show settings, change theme?
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            StartingWindow startingWindow = new StartingWindow();
            startingWindow.Show();
            this.Close();
        }
    }
}
