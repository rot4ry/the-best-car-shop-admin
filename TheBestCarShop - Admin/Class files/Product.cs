using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestCarShop
{
    public class Product
    {
        public int ProductID { get; private set; }
        //this part fits in:
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int CarFirstProdYear { get; set; }
        public int CarLastProdYear { get; set; }

        //and costs:
        public decimal Price { get; set; }

        //product details
        public string Name { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string PartCode { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
    }
}