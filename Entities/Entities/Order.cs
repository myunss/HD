using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public string User { get; set; }
        public decimal ActualPrice { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
