using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestCarShop
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string CompanyName { get; set; } //not a required field
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string BuildingNumber { get; set; }

        //login data
        public string Username { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }

    }
}
