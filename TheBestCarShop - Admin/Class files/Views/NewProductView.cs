using System.ComponentModel;

namespace TheBestCarShop___Admin.Class_files.Views
{
    public class NewProductView : INotifyPropertyChanged
    {
        /*
         * This class is a modified version of Product class.
         * This should be used as a representation of what an user can see
         * while trying to add a new product to the database.
         */

        public event PropertyChangedEventHandler PropertyChanged;

        private string carbrand;
        public string CarBrand
        {
            get
            {
                return carbrand;
            }
            set
            {
                if (carbrand != value)
                {
                    carbrand = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CarBrand"));
                }
            }
        }

        private string carmodel;
        public string CarModel
        {
            get
            {
                return carmodel;
            }
            set
            {
                if (carmodel != value)
                {
                    carmodel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CarModel"));
                }
            }
        }

        private int fprodyear;
        public int CarFirstProdYear
        {
            get
            {
                return fprodyear;
            }
            set
            {
                if (fprodyear != value)
                {
                    fprodyear = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CarFirstProdYear"));
                }
            }
        }

        private int lprodyear;
        public int CarLastProdYear
        {
            get
            {
                return lprodyear;
            }
            set
            {
                if (lprodyear != value)
                {
                    lprodyear = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CarLastProdYear"));
                }
            }
        }

        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price != value)
                {
                    price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                }
            }
        }


        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private string category;
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                if (category != value)
                {
                    category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category"));
                }
            }
        }


        private string manufacturer;
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (manufacturer != value)
                {
                    manufacturer = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Manufacturer"));
                }
            }
        }

        public string PartCode { get; set; }

        private bool isavailable;
        public bool IsAvailable
        {
            get
            {
                return isavailable;
            }
            set
            {
                if (isavailable != value)
                {
                    isavailable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsAvailable"));
                }
            }
        }

        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Quantity"));
                }
            }
        }

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
