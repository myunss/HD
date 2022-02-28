using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.RequestModel.Campaign
{
    public class CreateCampaignRequestModel
    {

        public string Name { get; set; }
        public int ProdcutId { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public bool Status { get; set; }
    }
}
