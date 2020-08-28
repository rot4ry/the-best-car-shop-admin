using System.ComponentModel;

namespace TheBestCarShop___Admin.Class_files.Views
{
    public class NewAdminView : INotifyPropertyChanged
    {
        /*
         * This is a modified version of Client class
         * created for the NewAdminValidator 
         * to use in AddAdminWindow
         */

        public event PropertyChangedEventHandler PropertyChanged;

        //User data
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


        private string companyName;
        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                if (companyName != value)
                {
                    companyName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CompanyName"));
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

        //Address data
        private string country;
        public string Country 
        {
            get
            {
                return country;
            }
            set
            {
                if (country != value)
                {
                    country = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Country"));
                }
            }
        }


        private string city;
        public string City 
        {
            get
            {
                return city;
            }
            set
            {
                if (city != value)
                {
                    city = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("City"));
                }
            }
        }


        private string street;
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (street != value)
                {
                    street = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Street"));
                }
            }
        }


        private string postcode;
        public string Postcode
        {
            get
            {
                return postcode;
            }
            set
            {
                if (postcode != value)
                {
                    postcode = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Postcode"));
                }
            }
        }


        private string buildingNumber;
        public string BuildingNumber
        {
            get
            {
                return buildingNumber;
            }
            set
            {
                if(buildingNumber != value)
                {
                    buildingNumber = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuildingNumber"));
                }
            }
        }

        
        //Login data
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


        private string password;
        public string Password 
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }


        //Validator errors
        private string errors;
        public string Errors
        {
            get 
            { 
                return errors; 
            }
            set
            {
                if (errors != value)
                {
                    errors = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Errors"));
                }
            }
        }
    }
}

