using DataAccess.Repository;
using DataAccess.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        ICampaignRepository Campaigns { get; }
        
    }
}
