using System.Windows;
using TheBestCarShop___Admin.Class_files.Basics;

namespace TheBestCarShop___Admin.IN_PROGRESS
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
    }
}
