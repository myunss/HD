using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.ResponseModel.Campaign
{
    public class GetCampaignInfoResponseModel
    {
        public bool Status { get; set; }
        public int TargetSalesCount { get; set; }
        public decimal Turnover { get; set; }
        public int TotalSales { get; set; }
        public decimal AverageItemPrice { get; set; }
        public string Message { get; set; }
    }
}
