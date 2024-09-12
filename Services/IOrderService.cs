using manage_product_service.Models;
using System.Collections.Generic;

namespace manage_product_service.Services
{
    public interface IOrderService
    {
        Order PlaceOrder(Order order);
        Order GetOrderById(int orderId);
    }
}
