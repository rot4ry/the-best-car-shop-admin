using System.ComponentModel;

namespace TheBestCarShop___Admin.Class_files.Basics
{
    public class Client : INotifyPropertyChanged
    {
        public int ClientID { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string BuildingNumber { get; set; }
        public string CompanyName { get; set; }
        public int IsAdmin { get; set; }



        //changable
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
        }


        private string secondName;
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                if (secondName != value)
                {
                    secondName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondName"));
                }
            }
        }


        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }


        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNumber"));
                }
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username != value)
                {
                    username = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Username"));
                }
            }
        }
        //changable but not visible for the user
        public string Password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Client()
        {

        }
        public Client(int id, string fname, string sname, string cname, string phone, string email, string country, string city, string street, string postcode, string building, int isadmin, string username, string password)
        {
            ClientID = id;
            FirstName = fname;
            SecondName = sname;
            CompanyName = cname;
            Email = email;
            PhoneNumber = phone;
            Country = country;
            City = city;
            Street = street;
            Postcode = postcode;
            BuildingNumber = building;
            IsAdmin = isadmin;
            Username = username;
            Password = password;
        }
    }
}
