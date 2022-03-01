using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Entities
{
    public class Product
    {
		
		public int ID { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string User { get; set; }
        public string CreateDate { get; set; }
        public bool IsActive { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal CampaignPrice { get; set; }
    }
}
