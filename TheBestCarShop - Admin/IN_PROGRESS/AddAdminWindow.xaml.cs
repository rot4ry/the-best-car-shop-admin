using System;
using System.Linq;
using System.Text;
using System.Windows;
using TheBestCarShop___Admin.Class_files.Basics;

namespace TheBestCarShop___Admin.IN_PROGRESS
{
    /// <summary>
    /// Interaction logic for AddAdminWindow.xaml
    /// </summary>
    public partial class AddAdminWindow : Window
    {
        private Client _ADMIN;
        private DatabaseHandler databaseHandler = new DatabaseHandler();

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
            //This code is basically copied from TheBestCarShop project
            //in order to maintain integrity of names kept in the database
            string name = firstNameTB.Text;
            string secondName = secondNameTB.Text;
            string variableToken = new Random().Next(10, 1000).ToString();

            try
            {
                name = name.Remove(new Random().Next(3, name.Length));
                secondName = secondName.Remove(new Random().Next(3, secondName.Length));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            string generatedUsername = new StringBuilder()
                .Append(name)
                .Append(secondName)
                .Append(variableToken)
                .ToString();

            usernameTB.Text = generatedUsername;
        }

        private void generatePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            int lengthOfPassword = new Random().Next(8, 10);
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= lengthOfPassword; i++)
            {
                GC.Collect();
                Random random = new Random();
                char c = (char)random.Next(33, 126);
                random.Next(1, 1000);
                GC.Collect();
                
                sb.Append(c);
            }
            string randomizedPassword = sb.ToString();

            passwordTB.Text = randomizedPassword;
        }

        private void addAdminButton_Click(object sender, RoutedEventArgs e)
        {
            addAdminButton.IsEnabled = false;
            //open a window for confirmation -> username and password
            
            int result = databaseHandler.AddAdmin(new Client
                {
                    FirstName       = @firstNameTB.Text,
                    SecondName      = @secondNameTB.Text,
                    CompanyName     = @companyNameTB.Text,
                    Email           = @emailTB.Text,
                    PhoneNumber     = @phoneTB.Text,
                    Country         = @countryTB.Text,
                    City            = @cityTB.Text,
                    Street          = @streetTB.Text,
                    Postcode        = @postcodeTB.Text,
                    BuildingNumber  = @buildingTB.Text,
                    Username        = @usernameTB.Text,
                    Password        = @passwordTB.Text,
                    IsAdmin         = 1
                }
            ); 

            if(result == 1)
            {
                MessageBox.Show("A new account has been created.", "Success!", MessageBoxButton.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again.", "Failure!", MessageBoxButton.OK);
                this.Close();
            }

        }
    }
}
