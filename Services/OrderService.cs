using manage_product_service.Models;
using System.Collections.Generic;
using System.Linq;

namespace manage_product_service.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new List<Order>();
        private readonly IProductService _productService; // Reference to the product service
        private int _nextOrderId = 1; // Auto-increment OrderId

        public OrderService(IProductService productService)
        {
            _productService = productService; // Inject product service to access product prices
        }

        public Order PlaceOrder(Order order)
        {
            // Auto-generate the OrderId
            order.OrderId = _nextOrderId++;

            // Calculate the total price
            decimal totalPrice = 0;
            foreach (var item in order.OrderItems)
            {
                // Get the product from the product service using the product ID
                var product = _productService.GetProductById(item.ProductId);
                if (product == null)
                {
                    // If the product is not found, return without placing the order (you can handle this in the controller)
                    return null;
                }

                // Multiply the product price by the quantity ordered and add to the total price
                totalPrice += product.Price * item.Quantity;
            }

            // Set the total price of the order
            order.TotalPrice = totalPrice;
            _orders.Add(order); // Add the order to the in-memory list

            return order;
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }
    }
}
