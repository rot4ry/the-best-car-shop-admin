using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Builder
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
