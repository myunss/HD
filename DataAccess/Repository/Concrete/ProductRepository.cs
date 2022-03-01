using Dapper;
using DataAccess.Repository.Abstract;
using Entities.DTO.RequestModel;
using Entities.DTO.RequestModel.Product;
using Entities.DTO.ResponseModel.Product;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration configuration;
        public ProductRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public CreateProductResponseModel CreateProduct(CreateProductRequestModel createProductRequestModel)
        {

            var sql = " insert into Product(ProductCode,Price,Stock,CreateDate,IsActive,OriginalPrice) values (@ProductCode,@Price,@Stock,GETDATE(),1,@PriceOriginal) ";
            var sql2 = "Select top 1 ID, ProductCode,Price,Stock from Product order by ID desc";
            CreateProductResponseModel createProductResponseModel = new CreateProductResponseModel();

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.ConnectionString = "Data Source=DESKTOP-D7BBR87;Initial Catalog=HD;Integrated Security=True;";
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var result = connection.Execute(sql, new { ProductCode = createProductRequestModel.ProductCode, Price = createProductRequestModel.Price, Stock = createProductRequestModel.Stock, PriceOriginal = createProductRequestModel.Price }, transaction: transaction);
                    if (result > 0)
                    {
                        var result2 = connection.QuerySingleOrDefault<CreateProductResponseModel>(sql2, transaction: transaction);
                        result2.Message = "Product created";
                        transaction.Commit();
                        return result2;
                    }

                    else
                    {
                        createProductResponseModel.Message = "Product could not be created";
                        return createProductResponseModel;
                    }
                }

            }
        }

        public GetProductInfoResponseModel GetProductInfo(GetProductInfoRequestModel getProductInfoRequestModel)
        {
            var sql = "select Price,Stock from Product where ID=@ProductId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.ConnectionString = "Data Source=DESKTOP-D7BBR87;Initial Catalog=HD;Integrated Security=True;";
                connection.Open();
                var result = connection.QuerySingleOrDefault<GetProductInfoResponseModel>(sql, new { ProductId = getProductInfoRequestModel.ProdcutId });
                result.Message = "Product P1 info";
                return result;
            }
        }
    }
}
