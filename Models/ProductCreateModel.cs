namespace manage_product_service.Models
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
