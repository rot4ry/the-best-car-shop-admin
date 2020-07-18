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
using System.Threading;
using System.Diagnostics;

namespace TheBestCarShop___Admin
{
    /// <summary>
    /// Interaction logic for AccountSettingsWindow.xaml
    /// </summary>
    public partial class AccountSettingsWindow : Window
    {
        private Client _ACCOUNTOWNER;
        private DatabaseHandler databaseHandler = new DatabaseHandler();

        public AccountSettingsWindow(Client _accountOwner)
        {
            InitializeComponent();
            _ACCOUNTOWNER = _accountOwner;
            
            accountDetailsGroupBox.DataContext = _ACCOUNTOWNER;
            passwordGroupBox.DataContext = _ACCOUNTOWNER;
            deleteGroupBox.DataContext = _ACCOUNTOWNER;
        }

        //UPDATE DETAILS BUTTONS
        private void updateFnameButton_Click(object sender, RoutedEventArgs e)
        {
            string updatedName = fnameTB.Text;
            int result = databaseHandler.UpdateClientField("FirstName", updatedName, _ACCOUNTOWNER.Username, _ACCOUNTOWNER.ClientID);
            
            if(result == 1)
                messageBox.Content = "First name - update successful!";
            
            else
                messageBox.Content = "First name - something went wrong. \nValue was not updated.";
            
            messageBox.Visibility = Visibility.Visible;

        }
        private void updateSnameButton_Click(object sender, RoutedEventArgs e)
        {
            string updatedSName = snameTB.Text;
            int result = databaseHandler.UpdateClientField("SecondName", updatedSName, _ACCOUNTOWNER.Username, _ACCOUNTOWNER.ClientID);
        
            if (result == 1)
                messageBox.Content = "Second name - update successful!";
            
            else
                messageBox.Content = "Second name - something went wrong. \nValue was not updated.";
            
            messageBox.Visibility = Visibility.Visible;
        }
        private void updateUnameButton_Click(object sender, RoutedEventArgs e)
        {
            //update of username should NOT be possible            
        }
        private void updateMailButton_Click(object sender, RoutedEventArgs e)
        {
            string updatedMail = mailTB.Text;
            int result = databaseHandler.UpdateClientField("Email", updatedMail, _ACCOUNTOWNER.Username, _ACCOUNTOWNER.ClientID);

            if (result == 1)
                messageBox.Content = "Email address- update successful!";
            
            else
                messageBox.Content = "Email address - something went wrong. \nValue was not updated.";
            
            messageBox.Visibility = Visibility.Visible;
        }
        private void updatePhoneButton_Click(object sender, RoutedEventArgs e)
        {
            string updatedPhone = phoneTB.Text;
            int result = databaseHandler.UpdateClientField("PhoneNumber", updatedPhone, _ACCOUNTOWNER.Username, _ACCOUNTOWNER.ClientID);

            if (result == 1)
                messageBox.Content = "Phone number - update successful!";
            
            else
                messageBox.Content = "Phone number - something went wrong. \nValue was not updated.";
            
            messageBox.Visibility = Visibility.Visible;
        }

        //CHANGE PASSWORD BUTTON
        private void updatePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = CP_oldPass.Password;
            string newPassword = CP_newPass.Password;
            string repNewPassword = CP_repeatNewPass.Password;


            if (oldPassword == "" || newPassword == "" || repNewPassword == "")
            {
                messageBox.Content = "Field(s) must not be empty.";
                messageBox.Visibility = Visibility.Visible;
            }
            else if(oldPassword != _ACCOUNTOWNER.Password)
            {
                messageBox.Content = "Check your password.";
                messageBox.Visibility = Visibility.Visible;
            }
            else if(newPassword != repNewPassword)
            {
                messageBox.Content = "            New passwords do not match. \nMake sure that both of them are the same.";
                messageBox.Visibility = Visibility.Visible;
            }
            else if (oldPassword == _ACCOUNTOWNER.Password &&
                    newPassword == repNewPassword)
            {
                int result = databaseHandler.UpdateClientField("Password", newPassword, _ACCOUNTOWNER.Username, _ACCOUNTOWNER.ClientID);

                if (result == 1)
                    messageBox.Content = "Password updated successfully!";
                else
                    messageBox.Content = "            Something went wrong. \nPassword was not updated.";

                messageBox.Visibility = Visibility.Visible;
            }
            _ACCOUNTOWNER = databaseHandler.GetClientDetails(_ACCOUNTOWNER.Username);
        }

    }
}
