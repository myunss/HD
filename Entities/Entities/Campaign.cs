using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Entities
{
    public class Campaign
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public double PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
       
        public DateTime CreateDate { get; set; }
        public int Limit { get; set; }
        public bool Status { get; set; }
        public DateTime CampaignFinishTime { get; set; }


    }
}
