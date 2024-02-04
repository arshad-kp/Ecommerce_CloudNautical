using Dapper;
using Ecommerce.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Ecommerce.Repository
{
    public interface ICustomerRepository
    {
        bool CheckCustomerValidityByEmailAndCustomerId(string emailId, string customerId);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private IConfiguration _Configuration;
        public CustomerRepository(IConfiguration configuration) 
        {
            _Configuration = configuration;
        }

        public bool CheckCustomerValidityByEmailAndCustomerId(string emailId, string customerId)
        {
            using (var connection = new SqlConnection(_Configuration.GetConnectionString("EcommerceConnection")))
            {
                connection.Open();

                var customers = connection.QueryFirstOrDefault<bool>(QueryConstants.CheckCustomerData, new { @CustomerId =customerId, @Email=emailId });

                return customers;
            }
        }
    }
}
