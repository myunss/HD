using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.RequestModel.Order
{
    public class CreateOrderRequestModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CampaignId { get; set; }
    }
}
