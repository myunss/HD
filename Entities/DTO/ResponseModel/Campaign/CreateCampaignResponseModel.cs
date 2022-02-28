using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ResponseModel.Campaign
{
    public class CreateCampaignResponseModel
    {
        public string Name { get; set; }

        public int ProductId { get; set; }
        public int Duration { get; set; }
        public int Limit { get; set; }
        public int TargetSalesCount { get; set; }
        public string Message { get; set; }
    }
}
