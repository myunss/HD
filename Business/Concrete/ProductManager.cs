using Business.Abstract;
using DataAccess.Repository.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTO.RequestModel;
using Entities.DTO.RequestModel.Product;
using Entities.DTO.ResponseModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProdcutService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository productRepository;

        public ProductManager(IUnitOfWork unitOfWork ,IProductRepository productRepository )
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }
        public CreateProductResponseModel CreateProduct(CreateProductRequestModel createProductRequestModel)
        {
            return productRepository.CreateProduct(createProductRequestModel);
        }

        public GetProductInfoResponseModel GetProductInfo(GetProductInfoRequestModel getProductInfoRequestModel)
        {
            return productRepository.GetProductInfo(getProductInfoRequestModel);
        }
    }
}
