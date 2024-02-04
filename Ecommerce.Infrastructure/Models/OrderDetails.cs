﻿namespace Ecommerce.Infrastructure.Models
{
    public class OrderDetails
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }

    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public DateTime DeliveryExpected { get; set; }
    }
    public class OrderItem
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
    }
}
