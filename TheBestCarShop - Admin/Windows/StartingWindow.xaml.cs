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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheBestCarShop___Admin.TODO;  //remove?

namespace TheBestCarShop___Admin
{
    /// <summary>
    /// Interaction logic for StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();
        
        public StartingWindow()
        {
            InitializeComponent();
        }
        
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //LOGIN LOGIC
            //DB CONNECTION, CHECKING VALIDATION

            string username = @usernameTextBox.Text;
            string password = @actualPasswordBox.Password;
            
            bool validationResult = 
                databaseHandler.CheckLoginData(username, password);

            if (validationResult)
            {
                LoggedInWindow loggedInWindow = new LoggedInWindow();
                loggedInWindow.Show();
                this.Close();
            }
            else
            {
                infoLabel.Content = "                    Failed to log in.     \n" +
                                    "Please check your login and password.";
                infoLabel.Visibility = Visibility.Visible;
            }
        }

        private void clearFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            usernameTextBox.Text = "Login";
            passwordTextBox.Text = "Password";
            passwordTextBox.Visibility = Visibility.Visible;
            infoLabel.Visibility = Visibility.Hidden;
            actualPasswordBox.Password = "";
        }

        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Visibility = Visibility.Hidden;
            actualPasswordBox.Focus();
        }

        private void actualPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(actualPasswordBox.Password == "")
            {
                passwordTextBox.Visibility = Visibility.Visible;
            }
        }

        private void usernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(usernameTextBox.Text == "Login")
                usernameTextBox.Clear();
        }

        private void usernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (usernameTextBox.Text == "")
                usernameTextBox.Text = "Login";                
        }
    }
}
