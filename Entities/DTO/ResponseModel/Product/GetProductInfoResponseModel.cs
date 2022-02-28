using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ResponseModel.Product
{
    public class GetProductInfoResponseModel
    {
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Message { get; set; }
    }
}
