using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                
                if (value != firstName)
                {
                    firstName = value;
                    
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
    }
}
