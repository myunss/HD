using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.RequestModel.Campaign
{
    public class GetCampaignInfoRequestModel
    {
        //Campaign C1 info; Status Active, Target Sales 100,
        //Total Sales 50, Turnover 5000, Average Item Price 100
        public int CampaignId { get; set; }
    }
}
