using Ecommerce.Application;
using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICustomer _customer;
        private readonly IOrder _order;
        public OrderController(ICustomer customer, IOrder order) 
        { 
            _customer = customer;
            _order = order;
        }

        [HttpPost]
        public IActionResult GetOrderDetails([FromBody] OrderInputModel orderInputModel)
        {
            if(!_customer.IsCutomerValid(orderInputModel.User, orderInputModel.CustomerId))
            {
                return BadRequest("CustomerId and EmailId Mismatch");
            }
            
            return Ok(_order.GetOrderDetailsByCustomerId(orderInputModel.CustomerId));
        }
    }
}
