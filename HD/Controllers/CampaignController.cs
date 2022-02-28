using Business.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTO.RequestModel.Campaign;
using Entities.DTO.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private ICampaignService campaignService;
        private readonly IConfiguration configuration;
        public CampaignController(IUnitOfWork unitOfWork, ICampaignService campaignService, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.campaignService = campaignService;
            this.configuration = configuration;
        }

        [HttpPost("CreateCampaign")]
        public IActionResult CreateCampaign(CreateCampaignRequestModel createCampaignRequestModel)
        {
            if (createCampaignRequestModel != null)
            {
                var data = campaignService.CreateCampaign(createCampaignRequestModel);
                if (data == null)
                {
                    return new JsonResult(new CustomResponseModel
                    {
                        Message = "Başarısız",
                        Result = HttpStatusCode.NotFound,
                        Data = ""
                    });
                }

                return new JsonResult(new CustomResponseModel
                {
                    Message = "Başarılı",
                    Result = HttpStatusCode.Created,
                    Data = data
                });
            }

            return new JsonResult(new CustomResponseModel
            {
                Message = "Başarısız",
                Result = HttpStatusCode.NotFound,
                Data = ""
            });
        }
        [HttpPost("GetCampaignInfo")]
        public IActionResult GetCampaignInfo(GetCampaignInfoRequestModel getCampaignInfoRequestModel)
        {
            if (getCampaignInfoRequestModel != null)
            {
                var data = campaignService.GetCampaignInfo(getCampaignInfoRequestModel);
                if (data == null)
                {
                    return new JsonResult(new CustomResponseModel
                    {
                        Message = "Başarısız",
                        Result = HttpStatusCode.NotFound,
                        Data = ""
                    });
                }

                return new JsonResult(new CustomResponseModel
                {
                    Message = "Başarılı",
                    Result = HttpStatusCode.OK,
                    Data = data
                });
            }

            return new JsonResult(new CustomResponseModel
            {
                Message = "Başarısız",
                Result = HttpStatusCode.NotFound,
                Data = ""
            });
        }
        //IncreaseTime(IncreaseTimeRequestModel increaseTimeRequestModel)
        [HttpPost("IncreaseTime")]
        public IActionResult IncreaseTime(IncreaseTimeRequestModel increaseTimeRequestModel)
        {
            if (increaseTimeRequestModel != null)
            {
                var data = campaignService.IncreaseTime(increaseTimeRequestModel);
                if (data == null)
                {
                    return new JsonResult(new CustomResponseModel
                    {
                        
                        Result = HttpStatusCode.NotFound,
                        Data = ""
                    });
                }

                return new JsonResult(new CustomResponseModel
                {
                   
                    Result = HttpStatusCode.OK,
                    Data = data
                });
            }

            return new JsonResult(new CustomResponseModel
            {
                Message = "Başarısız",
                Result = HttpStatusCode.NotFound,
                Data = ""
            });
        }
    }
}
