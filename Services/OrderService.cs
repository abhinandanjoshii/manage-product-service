using manage_product_service.Models;
using System.Collections.Generic;
using System.Linq;

namespace manage_product_service.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new List<Order>();
        private readonly IProductService _productService; 
        private int _nextOrderId = 1;

        public OrderService(IProductService productService)
        {
            _productService = productService; 
        }

        public Order PlaceOrder(Order order)
        {
            order.OrderId = _nextOrderId++;

            // Calculate the total price
            decimal totalPrice = 0;
            foreach (var item in order.OrderItems)
            {
                // Get the product from the product service using the product ID
                var product = _productService.GetProductById(item.ProductId);
                if (product == null)
                {
                    return null;
                }

                totalPrice += product.Price * item.Quantity;
            }

            order.TotalPrice = totalPrice;
            _orders.Add(order); 

            return order;
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
