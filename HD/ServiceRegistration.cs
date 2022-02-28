using Business.Abstract;
using Business.Concrete;
using DataAccess.Repository;
using DataAccess.Repository.Abstract;
using DataAccess.Repository.Concrete;
using DataAccess.UnitOfWork.Abstract;
using DataAccess.UnitOfWork.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD
{
    public static class ServiceRegistration
    {
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
			//services.AddTransient<ILoggerManager, LoggerManager>();
			
			//services.AddTransient<IProductService, ProductManager>();
			//services.AddTransient<IProductRepository, ProductRepository>();
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProdcutService, ProductManager>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderManager>();
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddTransient<ICampaignService, CampaignManager>();
          
        }
    }
}
