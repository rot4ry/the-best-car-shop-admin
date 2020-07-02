using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Database_Builder
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
        public string PartName { get; set; }
        public string PartCategory { get; set; }
        public string PartManufacturer { get; set; }
        public string PartCode { get; set; }
        public bool IsAvailable { get; set; }
        public int QtAvailable { get; set; }


        public Product()
        {

        }

        
        public Product(
        
            string carBrand, string carModel, int firstYear, int lastYear,
            decimal price,
            string partName, string partCategory, string partManufacturer, string partCode,
            bool isAvailable, int qtAvailable)
        {
            //this one wasn't particulary meant to be used by the user
            //using this in InputBuilder.BuildProduct() causes some massive errors
            //somehow
            CarBrand = carBrand;
            CarModel = carModel;
            CarFirstProdYear = firstYear;
            CarLastProdYear = lastYear;

            Price = price;

            PartName = partName;
            PartCategory = partCategory;
            PartManufacturer = partManufacturer;
            PartCode = partCode;
            IsAvailable = isAvailable;
            QtAvailable = qtAvailable;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Id:                 {ProductID}"); //managed by the Context modelBuilder
            Console.WriteLine($"Code:               {PartCode}");
            Console.WriteLine($"Part name:          {PartName}");
            Console.WriteLine($"Category:           {PartCategory}");
            Console.WriteLine($"Manufactured by:    {PartManufacturer}");
            Console.WriteLine($"Price:              {Price}");
            
            Console.WriteLine("Fits in: ");
            Console.WriteLine($"Brand:              {CarBrand}");
            Console.WriteLine($"Model:              {CarModel}");
            Console.WriteLine($"Produced from       {CarFirstProdYear} to {CarLastProdYear}");
            Console.WriteLine($"Is available:       {IsAvailable}");
            Console.WriteLine($"Quantity available: {QtAvailable}");
        }
    }
}
