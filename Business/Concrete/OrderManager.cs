using Business.Abstract;
using DataAccess.Repository.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.DTO.RequestModel.Order;
using Entities.DTO.ResponseModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderRepository orderRepository;

        public OrderManager(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
        }
        public CreateOrderResponseModel CreateOrder(CreateOrderRequestModel createOrderRequestModel)
        {
            return orderRepository.CreateOrder(createOrderRequestModel);
        }
    }
}
