using System.Windows;
using System.Windows.Documents;
using System.Collections.Generic;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Class_files.Viewmodels;
using System;

namespace TheBestCarShop___Admin.IN_PROGRESS
{
    /// <summary>
    /// Interaction logic for ClientListWindow.xaml
    /// </summary>
    public partial class UsersListWindow : Window
    {
        private DatabaseHandler databaseHandler = new DatabaseHandler();

        private List<Client> clientList = new List<Client>();
        private List<ClientInListViewmodel> _ClientList_SRC = new List<ClientInListViewmodel>();
        
        public UsersListWindow()
        {
            InitializeComponent();
            clientList = databaseHandler.GetClientsList();
            ManageSearchData();
        }

        private void ManageSearchData()
        {
            _ClientList_SRC.Clear();

            foreach(Client client in clientList)
            {
                ClientInListViewmodel clientModel = new ClientInListViewmodel();
                clientModel.Client = client;
                _ClientList_SRC.Add(clientModel);
            }

            searchResultsLB.ItemsSource = _ClientList_SRC;
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
