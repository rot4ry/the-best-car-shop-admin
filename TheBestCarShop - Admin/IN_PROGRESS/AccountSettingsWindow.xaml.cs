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
    /// Interaction logic for AccountSettingsWindow.xaml
    /// </summary>
    public partial class AccountSettingsWindow : Window
    {
        private Client _ACCOUNTOWNER;
        public AccountSettingsWindow(Client _accountOwner)
        {
            InitializeComponent();
            _ACCOUNTOWNER = _accountOwner;

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            accountDetailsGroupBox.DataContext  = _ACCOUNTOWNER;
            passwordGroupBox.DataContext        = _ACCOUNTOWNER;
            deleteGroupBox.DataContext          = _ACCOUNTOWNER;
        }

        private void updateSnameButton_Click(object sender, RoutedEventArgs e)
        {
            //update second name

        }
    }
}
