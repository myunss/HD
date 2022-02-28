using DataAccess.Repository;
using DataAccess.Repository.Abstract;
using DataAccess.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository,IOrderRepository orderRepository,ICampaignRepository campaignRepository) 
        {
            Products = productRepository;
            Orders = orderRepository;
            Campaigns = campaignRepository;
        }

        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public ICampaignRepository Campaigns { get; }

    }

    
}
