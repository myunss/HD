using Business.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTO.RequestModel.Order;
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
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IOrderService orderService;
        private readonly IConfiguration configuration;
        public OrderController(IUnitOfWork unitOfWork, IOrderService orderService , IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.orderService = orderService;
            this.configuration = configuration;
        }

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(CreateOrderRequestModel createOrderRequestModel)
        {
            if (createOrderRequestModel != null)
            {
                var data = orderService.CreateOrder(createOrderRequestModel);
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
    }
}
