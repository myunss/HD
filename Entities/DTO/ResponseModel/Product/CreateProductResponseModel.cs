using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ResponseModel.Product
{
    public class CreateProductResponseModel
    {
        //Product created; code P1, price 100, stock 1000
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Message { get; set; }
    }
}
