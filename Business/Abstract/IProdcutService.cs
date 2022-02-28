using Entities.DTO.RequestModel;
using Entities.DTO.RequestModel.Product;
using Entities.DTO.ResponseModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProdcutService
    {
        CreateProductResponseModel CreateProduct(CreateProductRequestModel createProductRequestModel);
        GetProductInfoResponseModel GetProductInfo(GetProductInfoRequestModel getProductInfoRequestModel);
    }
}
