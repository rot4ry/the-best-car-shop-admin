using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Database_Builder
{
    public class Order
    {
        public int OrderID { get; set; } //PK
        public int CustomerID { get; set; } //FK
        public DateTime ReceivedDate { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public bool IsPlaced { get; set; } //shopping kart position when false
    }
}

