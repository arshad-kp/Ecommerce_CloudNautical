using Dapper;
using Ecommerce.Infrastructure.Constants;
using Ecommerce.Repository.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Ecommerce.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDetailsReadModel> GetOrderDetailsByCustomerId(string customerId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        public OrderRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public IEnumerable<OrderDetailsReadModel> GetOrderDetailsByCustomerId(string customerId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EcommerceConnection")) )
            {
                var orderDetails = connection.Query<OrderDetailsReadModel>(QueryConstants.GetOrderDetailsByCustomerId, new { @CustomerId = customerId});
                return orderDetails;
            }
        }
    }
}
