using Ecommerce.Infrastructure.Models;
using Ecommerce.Repository;

namespace Ecommerce.Application
{
    public interface IOrder
    {
        OrderDetails GetOrderDetailsByCustomerId(string customerId);
    }

    public class Order : IOrder
    {
        public IOrderRepository _orderRepository { get; set; }
        public Order(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
        }
        public OrderDetails GetOrderDetailsByCustomerId(string customerId)
        {
            var orders = _orderRepository.GetOrderDetailsByCustomerId(customerId);
            var orderDetails = new OrderDetails();
            orderDetails.Customer = new Infrastructure.Models.Customer
            {
                FirstName = orders.FirstOrDefault().FirstName,
                LastName = orders.FirstOrDefault().LastName
            };

            var latestOrder = orders.FirstOrDefault();
            if (latestOrder != null)
            {
                orderDetails.Order = new Infrastructure.Models.Order
                {
                    DeliveryAddress = latestOrder.DeliveryAddress,
                    OrderDate = latestOrder.OrderDate,
                    DeliveryExpected = latestOrder.DeliveryExpected,
                    OrderNumber = latestOrder.OrderId
                };

                orderDetails.Order.OrderItems = orders.Select(x => new OrderItem
                {
                    Product = x.ProductName,
                    Quantity = x.Quantity,
                    PriceEach = x.Price
                }).ToList();
            }
            return orderDetails;
        }
    }
}
