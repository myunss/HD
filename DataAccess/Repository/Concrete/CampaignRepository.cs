using Dapper;
using Entities.DTO.RequestModel.Campaign;
using Entities.DTO.ResponseModel.Campaign;
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
    public class CampaignRepository : ICampaignRepository
    {
        private readonly IConfiguration configuration;
        public CampaignRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public CreateCampaignResponseModel CreateCampaign(CreateCampaignRequestModel createCampaignRequestModel)
        {
            var sql = " insert into Campaign(Name,ProductId,Duration,PriceManipulationLimit,TargetSalesCount,CreateDate,Status,CampaignFinishTime) values(@Name,@ProductId,@Duration,@PriceManipulationLimit,@TargetSalesCount,GETDATE(),@Status,@CampaignFinishTime) ";
            var sql2 = "Select top 1 Name,ProductId,Duration,PriceManipulationLimit,TargetSalesCount,CampaignFinishTime from Campaign order by ID desc";

            CreateCampaignResponseModel createCampaignResponseModel = new CreateCampaignResponseModel();

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.ConnectionString = "Data Source=DESKTOP-D7BBR87;Initial Catalog=HD;Integrated Security=True;";
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    DateTime CampaignFinishTime = DateTime.Now.AddHours(createCampaignRequestModel.Duration);
                    var result = connection.Execute(sql, new { Name = createCampaignRequestModel.Name, ProductId = createCampaignRequestModel.ProdcutId, Duration = createCampaignRequestModel.Duration, PriceManipulationLimit = createCampaignRequestModel.PriceManipulationLimit, TargetSalesCount = createCampaignRequestModel.TargetSalesCount, Status = createCampaignRequestModel.Status, CampaignFinishTime = CampaignFinishTime }, transaction: transaction);
                    if (result > 0)
                    {
                        var result2 = connection.QuerySingleOrDefault<CreateCampaignResponseModel>(sql2, transaction: transaction);
                        result2.Message = "Campaign created";
                        transaction.Commit();
                        return result2;
                    }

                    else
                    {
                        createCampaignResponseModel.Message = "Campaign could not be created";
                        return createCampaignResponseModel;
                    }
                }

            }
        }

        public GetCampaignInfoResponseModel GetCampaignInfo(GetCampaignInfoRequestModel getCampaignInfoRequestModel)
        {
            var sql = " select  [Status],TargetSalesCount from Campaign where ID=@CampaignId";
            var sql2 = "select Quantity,ActualPrice from [Order] where CampaignId= @CampaignId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.ConnectionString = "Data Source=DESKTOP-D7BBR87;Initial Catalog=HD;Integrated Security=True;";
                connection.Open();
                var result = connection.QuerySingleOrDefault<GetCampaignInfoResponseModel>(sql, new { CampaignId = getCampaignInfoRequestModel.CampaignId });
                var result2 = connection.Query<Order>(sql2, new { CampaignId = getCampaignInfoRequestModel.CampaignId });
                int TotalSales = 0;
                decimal Turnover = 0;
                foreach (var item in result2)
                {
                    TotalSales = item.Quantity + TotalSales;
                    Turnover = (item.Quantity * item.ActualPrice) + Turnover;

                }
                result.TotalSales = TotalSales;
                result.Turnover = Turnover;
                result.AverageItemPrice = Turnover / TotalSales;

                result.Message = "Product P1 info";
                return result;
            }
        }

        public IncreaseTimeResponseModel IncreaseTime(IncreaseTimeRequestModel increaseTimeRequestModel)
        {
            GetCampaignInfoRequestModel getCampaignInfoRequestModel = new GetCampaignInfoRequestModel();
            GetCampaignInfoResponseModel getCampaignInfoResponseModel = new GetCampaignInfoResponseModel();
            var sql = "Select*from Campaign where ID=@Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.ConnectionString = "Data Source=DESKTOP-D7BBR87;Initial Catalog=HD;Integrated Security=True;";
                connection.Open();
                var result = connection.QuerySingleOrDefault<Campaign>(sql, new { ID = increaseTimeRequestModel.CampaignId });
                if (increaseTimeRequestModel.CampaignId > 0)
                {
                    getCampaignInfoRequestModel.CampaignId = increaseTimeRequestModel.CampaignId;
                    getCampaignInfoResponseModel = GetCampaignInfo(getCampaignInfoRequestModel);
                }
                //Hedefin gerçekleşme yüzdesini buluyoruz
                double TotalSales = getCampaignInfoResponseModel.TotalSales;
                double TargetSalesCount = getCampaignInfoResponseModel.TargetSalesCount;
                double percent = TotalSales / TargetSalesCount;
                //Hedefin %15 veya daha aşağındaysa fiyat düzenlemesi yapıyoruz

                if (percent < 0.15)
                {
                    decimal PriceManipulationLimit = (decimal)result.PriceManipulationLimit;
                    
                    var Product = "Select*from Product where ID=@ID";
                    var ProductResult = connection.QuerySingleOrDefault<Product>(Product, new { ID = result.ProductId });
                    decimal ProductPrice = ProductResult.Price;
                    ProductPrice= ProductPrice - ((ProductPrice / 100)*PriceManipulationLimit);
                }

                IncreaseTimeResponseModel increaseTimeResponseModel = new IncreaseTimeResponseModel();
                return increaseTimeResponseModel;
            }

        }
    }
}
