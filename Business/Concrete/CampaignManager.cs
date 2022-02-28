using Business.Abstract;
using DataAccess.Repository;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTO.RequestModel.Campaign;
using Entities.DTO.ResponseModel.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICampaignRepository campaignRepository;

        public CampaignManager(IUnitOfWork unitOfWork, ICampaignRepository campaignRepository)
        {
            this.unitOfWork = unitOfWork;
            this.campaignRepository = campaignRepository;
        }
        public CreateCampaignResponseModel CreateCampaign(CreateCampaignRequestModel createCampaignRequestModel)
        {
            return campaignRepository.CreateCampaign(createCampaignRequestModel);
        }

        public GetCampaignInfoResponseModel GetCampaignInfo(GetCampaignInfoRequestModel getCampaignInfoRequestModel)
        {
            return campaignRepository.GetCampaignInfo(getCampaignInfoRequestModel);
        }

        public IncreaseTimeResponseModel IncreaseTime(IncreaseTimeRequestModel increaseTimeRequestModel)
        {
            return campaignRepository.IncreaseTime(increaseTimeRequestModel);
        }
    }
}
