using Dapper;
using DataAccess.Repository.Abstract;
using Entities.DTO.RequestModel.Order;
using Entities.DTO.ResponseModel.Order;
using HD.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration configuration;
        public OrderRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public CreateOrderResponseModel CreateOrder(CreateOrderRequestModel createOrderRequestModel)
        {
            var sql = " insert into [Order] (ProductId,Quantity,CreateDate,ActualPrice,CampaignId) values(@ProductId,@Quantity,GETDATE(),@ActualPrice,@CampaignId) ";
            var sql2 = "Select top 1 ProductId,Quantity  from [Order] order by ID desc";
            var sql3 = "Select Price from Product where ID=@ProductId and IsActive=1";
            CreateOrderResponseModel createOrderResponseModel = new CreateOrderResponseModel();

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.ConnectionString = "Data Source=DESKTOP-D7BBR87;Initial Catalog=HD;Integrated Security=True;";
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var result3 = connection.QuerySingleOrDefault<Product>(sql3, new { ProductId = createOrderRequestModel.ProductId },transaction:transaction);
                    decimal price = result3.Price;
                    var result = connection.Execute(sql, new { ProductId = createOrderRequestModel.ProductId, Quantity = createOrderRequestModel.Quantity, ActualPrice=price, CampaignId=createOrderRequestModel.CampaignId }, transaction: transaction);
                    if (result > 0)
                    {
                        var result2 = connection.QuerySingleOrDefault<CreateOrderResponseModel>(sql2, transaction: transaction);
                        result2.Message = "Order created";
                        transaction.Commit();
                        return result2;
                    }

                    else
                    {
                        createOrderResponseModel.Message = "Order could not be created";
                        return createOrderResponseModel;
                    }
                }

            }
        }
    }
}
