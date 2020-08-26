using System.Windows;
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
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void generateUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            usernameTB.Text = "testLoginu";
        }
        private void generatePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            passwordTB.Text = "testHasla";
        }


        private void addAdminButton_Click(object sender, RoutedEventArgs e)
        {
            //insert into the DB
            //open a windof for confirmation -> username and password
        }
    }
}
