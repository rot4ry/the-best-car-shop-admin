using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TheBestCarShop___Admin.Class_files.Basics;
using TheBestCarShop___Admin.Class_files.Viewmodels;

namespace TheBestCarShop___Admin.Windows
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
            conditionStringTB.Text = "";
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchCondition = conditionStringTB.Text;

            switch (conditionsCB.SelectedIndex)
            {
                case 0: //None
                    searchResultsLV.ItemsSource = _ClientList_SRC;
                    break;

                case 1: //Only admins
                    searchResultsLV.ItemsSource = _ClientList_SRC
                        .Where(x => x.Client.IsAdmin == 1);
                    break;

                case 2: //Only clients
                    searchResultsLV.ItemsSource = _ClientList_SRC
                        .Where(x => x.Client.IsAdmin == 0);
                    break;

                case 3: //ID

                    try
                    {
                        int id;
                        Int32.TryParse(searchCondition, out id);

                        if (id != 0)
                        {
                            if (_ClientList_SRC
                                .Where(x => x.Client.ClientID == id)
                                                .ToList().Count() != 0)
                            {
                                searchResultsLV.ItemsSource = _ClientList_SRC
                                                                .Where(x => x.Client.ClientID == id);
                            }
                            else
                            {
                                int maxid = _ClientList_SRC
                                    .Select(x => x.Client.ClientID)
                                    .Max();
                                MessageBox.Show($"Maximum ID found in the database is: {maxid}", "You exceeded the maximum ID value.", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please check if the ID you entered is a number.", "Something went wrong.", MessageBoxButton.OK);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 4: //First name
                    searchResultsLV.ItemsSource = _ClientList_SRC
                        .Where(x => x.Client.FirstName.ToLower()
                        .Contains(
                            searchCondition.ToLower()
                            )
                        );
                    break;

                case 5: //Second name
                    searchResultsLV.ItemsSource = _ClientList_SRC
                        .Where(x => x.Client.SecondName.ToLower()
                        .Contains(
                            searchCondition.ToLower()
                            )
                        );
                    break;

                case 6: //Email
                    searchResultsLV.ItemsSource = _ClientList_SRC
                        .Where(x => x.Client.Email.ToLower()
                        .Contains(
                            searchCondition.ToLower()
                            )
                        );
                    break;

                case 7: //Phone
                    searchResultsLV.ItemsSource = _ClientList_SRC
                        .Where(x => x.Client.PhoneNumber
                        .Contains(
                            searchCondition
                            )
                        );
                    break;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
