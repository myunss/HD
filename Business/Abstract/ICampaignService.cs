using Entities.DTO.RequestModel.Campaign;
using Entities.DTO.ResponseModel.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        CreateCampaignResponseModel CreateCampaign(CreateCampaignRequestModel createCampaignRequestModel);
        GetCampaignInfoResponseModel GetCampaignInfo(GetCampaignInfoRequestModel getCampaignInfoRequestModel);
        IncreaseTimeResponseModel IncreaseTime(IncreaseTimeRequestModel increaseTimeRequestModel);
    }
}
