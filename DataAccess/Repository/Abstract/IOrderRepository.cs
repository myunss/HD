using Entities.DTO.RequestModel.Order;
using Entities.DTO.ResponseModel.Order;
using Entities.DTO.ResponseModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Abstract
{
    public interface IOrderRepository
    {
        CreateOrderResponseModel CreateOrder(CreateOrderRequestModel createOrderRequestModel);
    }
}
