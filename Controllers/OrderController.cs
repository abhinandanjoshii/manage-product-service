using Microsoft.AspNetCore.Mvc;
using manage_product_service.Models;
using manage_product_service.Services;

namespace manage_product_service.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("placingorder")]
        public IActionResult PlaceOrder(OrderCreateModel orderCreateModel)
        {
            var order = new Order
            {
                CustomerName = orderCreateModel.CustomerName,
                OrderItems = orderCreateModel.OrderItems
            };

            var placedOrder = _orderService.PlaceOrder(order);

            return Ok(placedOrder);
        }

        [HttpPost("getorderdetail")]
        public IActionResult GetOrderById(OrderIdRequestModel orderIdRequestModel)
        {
            var order = _orderService.GetOrderById(orderIdRequestModel.OrderId);
            if (order == null) return NotFound();

            return Ok(order);
        }
    }
}
