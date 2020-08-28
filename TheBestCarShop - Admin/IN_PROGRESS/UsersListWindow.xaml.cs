using System.Windows;

namespace TheBestCarShop___Admin.IN_PROGRESS
{
    /// <summary>
    /// Interaction logic for ClientListWindow.xaml
    /// </summary>
    public partial class UsersListWindow : Window
    {
        public UsersListWindow()
        {
            InitializeComponent();
        }

        private void conditionsCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Searching");
        }
    }
}
