using System.Windows;
using System.Collections.Generic;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Class_files.Viewmodels;

namespace TheBestCarShop___Admin.IN_PROGRESS
{
    /// <summary>
    /// Interaction logic for UsersListWindow.xaml
    /// </summary>
    public partial class UsersListWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();

        private List<Client> clientList = new List<Client>();
        private List<ClientInList_Viewmodel> _ClientList_SRC = new List<ClientInList_Viewmodel>();

        private List<string> _SearchConditions_SRC = new List<string>()
        {
            "None", "Only admins", "Only clients",
            "ID", "First name", "Second name", "Email address", "Phone number"
        };


        public UsersListWindow()
        {
            InitializeComponent();
            clientList = databaseHandler.GetClientsList();
            conditionsCB.ItemsSource = _SearchConditions_SRC;
            ManageSearchData();
        }

        private void ManageSearchData()
        {
            _ClientList_SRC.Clear();

            foreach(Client client in clientList)
            {
                ClientInList_Viewmodel clientModel = new ClientInList_Viewmodel();
                clientModel.Client = client;
                _ClientList_SRC.Add(clientModel);
            }

            searchResultsLV.ItemsSource = _ClientList_SRC;
        }

        private void conditionsCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if( conditionsCB.SelectedIndex == 0 ||
                conditionsCB.SelectedIndex == 1 ||
                conditionsCB.SelectedIndex == 2  )
            {
                conditionStringTB.IsEnabled = false;
            }
            else
            {
                conditionStringTB.IsEnabled = true;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            //"None","Only admins", "Only clients"
            //"ID", "First name", "Second name", "Email address", "Phone number",
            //
        }
    }
}
