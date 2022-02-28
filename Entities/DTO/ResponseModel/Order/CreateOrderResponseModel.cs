using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ResponseModel.Order
{
    public class CreateOrderResponseModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ActualPrice { get; set; }
        public string Message { get; set; }
    }
}
