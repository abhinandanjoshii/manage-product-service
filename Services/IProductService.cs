using manage_product_service.Models;
using System.Collections.Generic;

namespace manage_product_service.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        Product AddProduct(Product product);
        Product UpdateProduct(int productId, Product product);
    }
}
