using Business.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTO.RequestModel;
using Entities.DTO.ResponseModel.Product;
using HD.Controllers;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace TDD
{
    public class UnitTest1: IClassFixture<ProductController>
    {
        
        ProductController ProductController;
        private readonly IUnitOfWork unitOfWork;
        private IProdcutService productService;
        private readonly IConfiguration configuration;
        
        public UnitTest1(ProductController ProductController, IUnitOfWork unitOfWork, IProdcutService productService, IConfiguration configuration)
        {
            this.ProductController = ProductController;
            this.unitOfWork = unitOfWork;
            this.productService = productService;
            this.configuration = configuration;


        }
        [Fact]
        
        public void Test1()
        {

            
            CreateProductRequestModel createProductRequestModel = new CreateProductRequestModel();

            createProductRequestModel.Price = 20;
            createProductRequestModel.ProductCode = "P1";
            createProductRequestModel.Stock = 30;

            
            var cd=  productService.CreateProduct(createProductRequestModel);
            Assert.NotNull(cd);
           
        }
    }
}
