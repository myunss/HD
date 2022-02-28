using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.RequestModel
{
    public class CreateProductRequestModel
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
