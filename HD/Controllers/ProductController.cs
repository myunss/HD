using Business.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTO.RequestModel;
using Entities.DTO.RequestModel.Product;
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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private IProdcutService productService;
        private readonly IConfiguration configuration;

        public ProductController(IUnitOfWork unitOfWork,IProdcutService productService,IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.productService = productService;
            this.configuration = configuration;
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(CreateProductRequestModel createProductRequestModel)
        {
            if (createProductRequestModel != null)
            {
                var data = productService.CreateProduct(createProductRequestModel);
                if (data ==null)
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

        [HttpPost("GetProductInfo")]
        public IActionResult GetProductInfo(GetProductInfoRequestModel getProductInfoRequestModel)
        {
            if (getProductInfoRequestModel != null)
            {
                var data = productService.GetProductInfo(getProductInfoRequestModel);
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
