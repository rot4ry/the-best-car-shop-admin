using System.Windows;
using TheBestCarShop___Admin.Class_files.Basics;

namespace TheBestCarShop___Admin.Windows
{
    /// <summary>
    /// Interaction logic for ClientDetailsWindow.xaml
    /// </summary>
    public partial class ClientDetailsWindow : Window
    {
        private Client DisplayedUser = new Client();
        public ClientDetailsWindow(Client requestedClient)
        {
            InitializeComponent();
            DisplayedUser = requestedClient;
            
            userDetailsGrid.DataContext     = DisplayedUser;
            accountDetailsGrid.DataContext  = DisplayedUser;
            addressDetailsGrid.DataContext  = DisplayedUser;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void accountDetailsGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(DisplayedUser.IsAdmin == 1)
            {
                adminInfo.Text = "Yes";
            }
            else if(DisplayedUser.IsAdmin == 0)
            {
                adminInfo.Text = "No";
            }
        }
    }
}
