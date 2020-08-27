using System.Windows;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Windows;

namespace TheBestCarShop___Admin.IN_PROGRESS
{
    /// <summary>
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        private Client _ACCOUNTOWNER;
        private DatabaseHandler databaseHandler = new DatabaseHandler();

        public LoggedInWindow(Client _accountOwner)
        {
            _ACCOUNTOWNER = _accountOwner;
            InitializeComponent();
        }

        
        //PRODUCTS BUTTONS
        private void productsButton_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow plw = new ProductListWindow();
            this.Hide();
            plw.ShowDialog();
            this.Show();
        }

        private void newProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow apw = new AddProductWindow();
            this.Hide();
            apw.ShowDialog();
            this.Show();
        }

        private void productStatsButton_Click(object sender, RoutedEventArgs e)
        {
            //show product statistics
            //TODO
        }


        //USERS BUTTONS
        private void viewAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            //show administrators list
            //TODO
        }

        private void viewUsersButton_Click(object sender, RoutedEventArgs e)
        {
            //show all normal users
            //TODO
        }

        private void newAdminButton_Click(object sender, RoutedEventArgs e)
        {
            AddAdminWindow aaw = new AddAdminWindow();
            this.Hide();
            aaw.ShowDialog();
            this.Show();    
        }

        private void clientStatsButton_Click(object sender, RoutedEventArgs e)
        {
            //show clients statistics
            //TODO
        }


        //OTHER BUTTONS
        private void accountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountSettingsWindow asw = new AccountSettingsWindow(_ACCOUNTOWNER);
            this.Hide();
            asw.ShowDialog();
            
            _ACCOUNTOWNER = databaseHandler.GetClientDetails(_ACCOUNTOWNER.Username);
            if(_ACCOUNTOWNER != null)
            {
                this.Show();
            }
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            //show settings, change theme with resources?
            //TODO
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            StartingWindow startingWindow = new StartingWindow();
            startingWindow.Show();
            this.Close();
        }
    }
}
