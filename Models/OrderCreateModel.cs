using System;
using System.Collections.Generic;

namespace manage_product_service.Models
{
    public class OrderCreateModel
    {
        public string CustomerName { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
