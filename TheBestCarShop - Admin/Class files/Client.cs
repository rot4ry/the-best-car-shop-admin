using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheBestCarShop___Admin
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
        public string FirstName {
            
            get { return firstName; }
        
            set {
                 
                if (firstName != value)
                {
                    firstName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
                    //throws an exception, probably not receiving an instance of Client
                    Console.WriteLine(firstName);
                }  
            } 
        }

        
        private string secondName;
        public string SecondName { get; set; }


        private string email;
        public string Email { get; set; }


        private string phoneNumber;
        public string PhoneNumber { get; set; }

        private string username;
        public string Username { get; set; }

        //changable but not visible for the user, thus not using OnPropertyChanged
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
