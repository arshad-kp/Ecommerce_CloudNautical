using Ecommerce.Repository;

namespace Ecommerce.Application
{
    public interface ICustomer
    {
        bool IsCutomerValid(string emailId, string customerId);
    }

    public class Customer : ICustomer
    {
        private readonly ICustomerRepository _customerRepository;
        public Customer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool IsCutomerValid(string emailId, string customerId)
        {
            return _customerRepository.CheckCustomerValidityByEmailAndCustomerId(emailId, customerId);
        }
    }
}
