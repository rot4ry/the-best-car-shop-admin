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
using TheBestCarShop___Admin.TODO;

namespace TheBestCarShop___Admin
{
    /// <summary>
    /// Interaction logic for StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        public StartingWindow()
        {
            InitializeComponent();
        }
            

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //LOGIN LOGIC
            //DB CONNECTION, CHECKING VALIDATION
            
            LoggedInWindow loggedInWindow = new LoggedInWindow();
            loggedInWindow.Show();
            this.Close();
        }

        private void clearFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            usernameTextBox.Text = "Login";
            passwordTextBox.Text = "Password";
        }

        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //disable visibility, switch focus to actualPasswordTextBox
            //when aPTB loses focus, it enables visibility if aPTB not changed
        }
    }
}
